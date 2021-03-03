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
            //Instantiate(pickupEffect, transform.position, transform.rotation);
            //pickupEffect.Play();
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
        yield return new WaitForSeconds(.5f);
        Collect = false;
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
