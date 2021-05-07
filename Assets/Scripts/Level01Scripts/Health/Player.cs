/* 
 * Made by Colton Henderson
 * This script controls the player
 * Checks player health
 * Checks player armor
 * Sets player death screen
 * Sets player taking damage
 * Gives health if health is picked up
 * Unused, but possible future implementation, focus functions
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] Text _currentHealthTextView;
    [SerializeField] Text _currentArmorTextView;
    public Camera cam;
    private AudioSource Impact;
    public AudioClip HurtSound;
    public AudioClip DeathSound;

    public Interactable focus;
    public int maxHealth = 100;
    public int currentHealth;
    public static int armor;
    public static int totalArmor;
    public static float speed;

    public HealthBar healthBar;



    //death
    public static bool playerIsDead;
    public GameObject deathMenuUI;
    public GameObject reticle;

    public Level01Controller level01Controller;
    

    

    // Start is called before the first frame update
    void Start()
    {
        playerIsDead = false;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        _currentHealthTextView.text = "Health: " + currentHealth.ToString();
        _currentArmorTextView.text = "Armor: " + totalArmor.ToString();
        Impact = GetComponent<AudioSource>();
        speed = PlayerMovement.GetSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        totalArmor = armor;
        _currentArmorTextView.text = "Armor: " + totalArmor.ToString();
        if (currentHealth == 0)
        {
            Die();
        }

        if (Input.GetMouseButton(2))
        {
            RemoveFocus();
        }

        if (Input.GetMouseButton(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if(Physics.Raycast(ray, out hit, 100))
            {
                Interactable interactable =  hit.collider.GetComponent<Interactable>();
                if(interactable != null)
                {
                    SetFocus(interactable);
                }
            }
        }
    }

    public static void AddArmor(int newArmor)
    {
        armor += newArmor;
    }

    public static void RemoveArmor(int oldArmor)
    {
        armor -= oldArmor;
    }

    private void SetFocus(Interactable newFocus )
    {
        if(newFocus != focus)
        {
            if(focus != null)
            {
                focus.OnDefocused();
            }
            focus = newFocus;
        }
        newFocus.OnFocused(transform);
        //playerMovement.FollowTarget(newFocus);
    }

    void RemoveFocus()
    {
        if (focus != null)
        {
            focus.OnDefocused();
        }
        focus = null;
    }

    private void Die()
    {
        Impact.PlayOneShot(DeathSound);
        deathMenuUI.SetActive(true);
        reticle.SetActive(false);
        Level01Controller.SetCurrentTime(0f);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        playerIsDead = true;
    }

    void TakeDamage(int damage)
    {
        //armor
        damage -= armor;
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        //clamp health
        currentHealth -= damage;
        if(currentHealth < 0)
        {
            currentHealth = 0;
        }
        if (currentHealth > 100)
        {
            currentHealth = 100;
        }

        //update healthbar/health point
        healthBar.SetHealth(currentHealth);
        _currentHealthTextView.text = "Health: " + currentHealth.ToString();
    }

    void Heal(int health)
    {
        health = Mathf.Clamp(health, 0, int.MaxValue);
        currentHealth += health;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        if (currentHealth > 100)
        {
            currentHealth = 100;
        }
        //update healthbar/health point
        healthBar.SetHealth(currentHealth);
        _currentHealthTextView.text = "Health: " + currentHealth.ToString();
    }

    private void OnTriggerEnter(Collider collider)
    {
        //float alteredSpeed;
        if(collider.tag == "Armor")
        {
            //armor += 2;
        }
        else if (collider.tag == "Health")
        {
            Heal(10);
        }
        else if(collider.tag == "Treasure")
        {
            level01Controller.AddToScore(10);
        }
        else if(collider.tag == "Bonus")
        {
            level01Controller.AddToScore(50);
        }
        else if (collider.tag == "SpeedUp")
        {
            Debug.Log("SpeedUp");
        }
        else if(collider.tag == "SlowDownPowerUp")
        {
            
        }
        else
        {
            Impact.PlayOneShot(HurtSound);
            TakeDamage(5);
        }
    }

    public static void SetAlteredSpeed(float alteredSpeed)
    {
        speed = alteredSpeed;
    }
    public static float GetNewSpeed()
    {
        return speed;
    }


    public static bool IsPlayerDead()
    {
        return playerIsDead;
    }
}
