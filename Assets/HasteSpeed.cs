using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasteSpeed : MonoBehaviour
{
    private AudioSource HasteCollect;
    public static float speed;
    //public ParticleSystem pickupEffect;

    void Start()
    {
        HasteCollect = GetComponent<AudioSource>();
        speed = PlayerMovement.GetSpeed();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            HasteCollect.Play();
            Player.SetAlteredSpeed(speed * 2);
            StartCoroutine("Destroy");
        }       
    }
    IEnumerator Destroy()
    {
        GetComponent<Collider>().enabled = false;
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
        Debug.Log("Gotta go fast!");
        yield return new WaitForSeconds(20f);
        Debug.Log("Stop being fast!");
        Player.SetAlteredSpeed(speed);
        gameObject.SetActive(false);        
    }
}
