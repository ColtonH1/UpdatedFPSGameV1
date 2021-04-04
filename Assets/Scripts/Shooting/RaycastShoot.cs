/*
 * This script determines what the player shoots at
 * This also plays the shooting sound and the impact sound
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class RaycastShoot : MonoBehaviour
{
    //variables for gun shooting
    public float gunDamage = 1;
    public float fireRate = .25f;
    public float weaponRange = 100f;
    public float hitForce = 100f;
    public Transform gunEnd;
    public static bool shot = false;

    //variables for camera and audio
    private Camera fpsCam;
    private WaitForSeconds shotDuration = new WaitForSeconds(.07f);
    private AudioSource fireAudio;
    public AudioClip impactClip;
    public AudioClip shootClip;
    private LineRenderer laserLine;
    private float nextFire; //how soon after each shot can we shoot again

    public static bool isPlayerDead; 


    void Start()
    {
        //get components
        laserLine = GetComponent<LineRenderer>();
        fireAudio = GetComponent<AudioSource>();
        fpsCam = GetComponentInParent<Camera>();
        isPlayerDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        isPlayerDead = Player.IsPlayerDead(); //player can't shoot if they're dead
        shot = false; //we haven't shot yet

        //check if: player shot gun, enough time has passed to shoot next shot, if player is alive, and if game is not paused
        if(Input.GetMouseButton(0) && Time.time > nextFire && !Player.playerIsDead && !Level01Controller.GameIsPaused)
        {
            nextFire = Time.time + fireRate; //set countdown for next shot

            StartCoroutine(ShotEffect()); //player shooting sound

            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0)); //set ray origin
            RaycastHit hit; //what we hit

            laserLine.SetPosition(0, gunEnd.position); //set position for where laser line comes out of

            //if the raycast comes from the orgin, goes forwars, hits the enemy, and is within range of fire:
            if(Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, weaponRange))
            {
                laserLine.SetPosition(1, hit.point); //set the position of the laser to the point it hit

                EnemyController health = hit.collider.GetComponent<EnemyController>(); //get the collider attached to the EnemyController script that was hit

                //if this enemy has health then take damage
                if(health != null)
                {
                    health.Damage(gunDamage);
                    shot = true;
                }
                //if the collider that was hit has a rigidbody, add force to it
                if(hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * hitForce);
                }
                
            }
            //if nothing was hit...
            else
            {
                laserLine.SetPosition(1, rayOrigin + (fpsCam.transform.forward * weaponRange)); //set position of the laser to be in front of player withing firing range
            }
        }
    }

    //delay shoot audio
    private IEnumerator ShotEffect()
    {
        fireAudio.PlayOneShot(shootClip); //play audio of firing

        laserLine.enabled = true; //show laser line
        yield return shotDuration; //wait .07s
        fireAudio.PlayOneShot(impactClip); //play impact sound
        laserLine.enabled = false; //turn off laser line
    }

    public static bool GetIfShot()
    {
        return shot;
    }
}
