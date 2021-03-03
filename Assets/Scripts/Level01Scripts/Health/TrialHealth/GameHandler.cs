using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    HealthSystem healthSystem;// = new HealthSystem(100);
    // Start is called before the first frame update
    void Start()
    {
        healthSystem = new HealthSystem(100);

        Debug.Log("Health: " + healthSystem.GetHealth());
        

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            healthSystem.Damage(5);
            Debug.Log("Health (damage): " + healthSystem.GetHealth());
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            healthSystem.Heal(5);
            Debug.Log("Health (heal): " + healthSystem.GetHealth());
        }
    }
}
