using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpeedUp : MonoBehaviour
{

    private AudioSource PowerUpSound;
    public static bool speedIsAltered = false;
    public static float speed;


    void Start()
    {
        PowerUpSound = GetComponent<AudioSource>();
        speed = PlayerMovement.GetSpeed();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player picked up speed");
            PowerUpSound.Play();
            Player.SetAlteredSpeed(speed * 2);
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
        yield return new WaitForSeconds(10f);
        Player.SetAlteredSpeed(speed);
        gameObject.SetActive(false);

    }
}
