using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusPoints : MonoBehaviour
{
    
    private AudioSource BonusCollect;
    //public ParticleSystem pickupEffect;


    void Start()
    {
        BonusCollect = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            //Instantiate(pickupEffect, transform.position, transform.rotation);
            //pickupEffect.Play();
            BonusCollect.Play();
            StartCoroutine("Destroy");
        }
        
        
    }

    IEnumerator Destroy()
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
        
    }
    /*
    public GameObject pickupEffect;
    private AudioSource ArmorAudio;
    public AudioClip ArmorClip;

    void Start()
    {
        ArmorAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Pickup();
        }
    }

    void Pickup()
    {
        ArmorAudio.PlayOneShot(ArmorClip);
        Instantiate(pickupEffect, transform.position, transform.rotation);
        Destroy(gameObject);
        
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(1f);
        pickupEffect.SetActive(false);

    }*/
}
