using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorSound : MonoBehaviour
{
    
    private AudioSource ArmorCollect;
    //public ParticleSystem pickupEffect;


    void Start()
    {
        ArmorCollect = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            //Instantiate(pickupEffect, transform.position, transform.rotation);
            //pickupEffect.Play();
            ArmorCollect.Play();
            Player.AddArmor(3);
            StartCoroutine("Destroy");
        }
        
        
    }

    IEnumerator Destroy()
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(10f);
        Player.RemoveArmor(3);
        gameObject.SetActive(false);
        
    }
}
