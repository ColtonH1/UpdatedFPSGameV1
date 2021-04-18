using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasteSpeed : MonoBehaviour
{
        private AudioSource HasteCollect ;
    //public ParticleSystem pickupEffect;
    // Start is called before the first frame update
    void Start()
    {
        HasteCollect = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            HasteCollect.Play();
            Level01Controller.SetCurrentTime(2.0f);
            StartCoroutine("Destroy");
        }       
    }
        IEnumerator Destroy()
    {
        Renderer[] rs = GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rs)
        r.enabled = false;
        Debug.Log("Gotta go fast!");
        yield return new WaitForSeconds(25f);
        Level01Controller.SetCurrentTime(1f);
        gameObject.SetActive(false);        
    }
}
