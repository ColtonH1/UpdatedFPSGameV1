using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float lookRadius = 10f;

    private Transform player;
    private Vector3 target;
    public static GameObject gunEnd;
    //public static bool alterSpeed = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector3(player.position.x, player.position.y, player.position.z);
    }

    private void Update()
    {
        //alterSpeed = SlowDown.GetAlteredSpeed();
        float distance = Vector3.Distance(player.position, transform.position);
        if (distance <= lookRadius)
        {
            Debug.Log("Not Slowed Down");
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }
        /*else if(distance <= lookRadius)
        {
            Debug.Log("Slowed Down");
            AlterSpeed(distance, transform, target, speed);
        }*/

        if(transform.position.x == target.x && transform.position.y == target.y && transform.position.z == target.z )
        {
            DestroyProjectile();
        }

        Destroy(gameObject, 2);
    }

    /*
    IEnumerator ReturnToNormal()
    {
        yield return new WaitForSeconds(10f);
        alterSpeed = false;
    }

    IEnumerator AlterSpeed(float distance, Transform transform, Vector3 target, float speed)
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime / 10);
        yield return new WaitForSeconds(10f);
        alterSpeed = false;

    }
    */
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            DestroyProjectile();             
        }
        else if (!other.CompareTag("Enemy"))
        {
            DestroyProjectile();
        }

    }

    private void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
