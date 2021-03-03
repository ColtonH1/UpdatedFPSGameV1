using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class RaycastShoot : MonoBehaviour
{

    public float gunDamage = 1;
    public float fireRate = .25f;
    public float weaponRange = 100f;
    public float hitForce = 100f;
    public Transform gunEnd;
    //public static int score = 0;
    public static bool shot = false;


    private Camera fpsCam;
    private WaitForSeconds shotDuration = new WaitForSeconds(.07f);
    private AudioSource fireAudio;
    public AudioClip impactClip;
    public AudioClip shootClip;
    private LineRenderer laserLine;
    private float nextFire;

    public static bool isPlayerDead;


    void Start()
    {
        laserLine = GetComponent<LineRenderer>();
        fireAudio = GetComponent<AudioSource>();
        //impactClip = GetComponent<AudioClip>();
        //shootClip = GetComponent<AudioClip>();
        fpsCam = GetComponentInParent<Camera>();
        isPlayerDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        isPlayerDead = Player.IsPlayerDead();
        shot = false;
        if(Input.GetMouseButtonDown(0) && Time.time > nextFire && !Player.playerIsDead && !Level01Controller.GameIsPaused)
        {
            nextFire = Time.time + fireRate;

            StartCoroutine(ShotEffect());

            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;

            laserLine.SetPosition(0, gunEnd.position);

            if(Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, weaponRange))
            {
                laserLine.SetPosition(1, hit.point);

                EnemyController health = hit.collider.GetComponent<EnemyController>();

                if(health != null)
                {
                    health.Damage(gunDamage);
                    shot = true;
                }
                if(hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * hitForce);
                }
                
            }
            else
            {
                laserLine.SetPosition(1, rayOrigin + (fpsCam.transform.forward * weaponRange));
            }
        }
    }

    //delay shoot audio
    private IEnumerator ShotEffect()
    {
        fireAudio.PlayOneShot(shootClip);

        laserLine.enabled = true;
        yield return shotDuration;
        fireAudio.PlayOneShot(impactClip);
        laserLine.enabled = false;
    }

    public static bool GetIfShot()
    {
        return shot;
    }

    /*public static int GetScore()
    {
        return score;
    }*/
}
