/* Made by Colton Henderson
 * This script Controlls the enemy
 * How the enemy faces the player
 * The radius of the enemy's view
 * The damage the enemy receives
 * How the enemy shoots
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10f;

    Transform target;
    NavMeshAgent agent;

    public float currentHealth = 3;
    private AudioSource shootAudio;
    public AudioClip impactClip;
    public AudioClip fireClip;
    public static int score = 0;
    public static bool gotShot = false;

    //shooting
    private float timeBtwnShots;
    public float startTimeBtwnShots;

    public GameObject projectile1;
    public GameObject Shoot_From;
    //public GameObject projectile2;

    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        shootAudio = GetComponent<AudioSource>();
        timeBtwnShots = startTimeBtwnShots;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {

            GetComponent<Oscillator>().enabled = false;
            Shoot();
            //HoldNavAgent();
            agent.SetDestination(target.position);
            Shoot();

            if (distance <= agent.stoppingDistance)
            {
                FaceTarget();
            }
        }
        else
        {
            //GetComponent<Oscillator>().enabled = true;

        }
    }

    private void Shoot()
    {
        if (timeBtwnShots <= 0)
        {
            Instantiate(projectile1, Shoot_From.transform.position, Quaternion.identity);
            //Instantiate(projectile2, transform.position, Quaternion.identity);
            shootAudio.PlayOneShot(fireClip);
            timeBtwnShots = startTimeBtwnShots;
        }
        else
        {
            timeBtwnShots -= Time.deltaTime;
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    public void Damage(float damageAmount)
    {
        score += 5;
        gotShot = true;
        currentHealth -= damageAmount;
        shootAudio.PlayOneShot(impactClip);
        agent.SetDestination(target.position);
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    public static bool GotShot()
    {
        return gotShot;
    }
}
