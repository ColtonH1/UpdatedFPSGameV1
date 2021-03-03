using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableBox : MonoBehaviour
{
    public int currentHealth = 3;
    private AudioSource impactAudio;

    void Start()
    {
        impactAudio = GetComponent<AudioSource>();
    }

    public void Damage(int damageAmount)
    {
        currentHealth -= damageAmount;
        impactAudio.Play();
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
