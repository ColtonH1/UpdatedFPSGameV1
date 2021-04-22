using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDown : MonoBehaviour
{
    
    private AudioSource PowerUpSound;
    public static bool speedIsAltered = false;
    public static float speed; //


    void Start()
    {
        PowerUpSound = GetComponent<AudioSource>();
        speed = PlayerMovement.GetSpeed(); //
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PowerUpSound.Play();
            Level01Controller.SetCurrentTime(0.5f);
            Player.SetAlteredSpeed(speed * 2); //
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
        yield return new WaitForSeconds(10f);
        Level01Controller.SetCurrentTime(1f);
        Player.SetAlteredSpeed(speed); //
        gameObject.SetActive(false);

    }
}
