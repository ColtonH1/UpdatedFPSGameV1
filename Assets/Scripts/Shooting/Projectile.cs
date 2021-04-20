/*
 * Made by Colton Henderson
 * This script checks if the player is within range of the enemy
 * If the player is in range, a projectile will be shot and destroyed upon hitting an object including the player, but not another enemy
 */

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

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector3(player.position.x, player.position.y, player.position.z);
    }

    private void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        if (distance <= lookRadius)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }

        if(transform.position.x == target.x && transform.position.y == target.y && transform.position.z == target.z )
        {
            DestroyProjectile();
        }

        Destroy(gameObject, 2);
    }

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
