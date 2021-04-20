/*
 * Made by Colton Henderson
 * This controls the treasure pickup
 * Sound will be played when the treasure is picked up
 * A function will allow level01controller script to see the treasure has been picked up
 * The mesh will be turned off so it cannot be seen anymore (if statement is used to check if object has children with mesh)
 * The collider will be turned off to not allow multiple pickups 
 * The object will be destroyed
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChest : MonoBehaviour
{
    
    private AudioSource TreasureCollect;
    private static bool Collect;
    //public ParticleSystem pickupEffect;


    void Start()
    {
        TreasureCollect = GetComponent<AudioSource>();
        Collect = false;
    }

    private void FixedUpdate()
    {
        Debug.Log("We collected: " + Collect);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            TreasureCollect.Play();
            Collect = true;
            StartCoroutine("Destroy");
        }
        
        
    }

    public static bool DidCollect()
    {
        return Collect;
    }

    IEnumerator Destroy()
    {
        if (!(GetComponent<MeshRenderer>() == null))
        {
            GetComponent<MeshRenderer>().enabled = false;
        }
        else
        {
            Renderer[] rs = GetComponentsInChildren<Renderer>();
            foreach (Renderer r in rs)
                r.enabled = false;
        }
        GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(1f);
        Collect = false;
        transform.root.gameObject.SetActive(false);
        
    }
}
