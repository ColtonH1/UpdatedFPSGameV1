using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDown : MonoBehaviour
{
    
    private AudioSource PowerUpSound;
    public static bool speedIsAltered = false;
    //public ParticleSystem pickupEffect;


    void Start()
    {
        PowerUpSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            //Instantiate(pickupEffect, transform.position, transform.rotation);
            //pickupEffect.Play();
            PowerUpSound.Play();
            Level01Controller.SetCurrentTime(0.5f);
            StartCoroutine("Destroy");
        }
        
        
    }

    IEnumerator Destroy()
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(10f);
        Level01Controller.SetCurrentTime(1f);
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
