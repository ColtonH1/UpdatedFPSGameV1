/*
 * This script was made by Colton Henderson
 * Thi script controls the secret bonus point
 * Sound will be played when the bonus point is picked up
 * The mesh will be turned off so it cannot be seen anymore (if statement is used to check if object has children with mesh)
 * The collider will be turned off to not allow multiple pickups 
 * The object will be destroyed
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusPoints : MonoBehaviour
{
    
    private AudioSource BonusCollect;


    void Start()
    {
        BonusCollect = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            BonusCollect.Play();
            StartCoroutine("Destroy");
        }
        
        
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
        gameObject.SetActive(false);
        
    }
}
