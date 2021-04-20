using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//written by Jason
//script is supposed to give power-ups a visual indicator for the player
//modified (Y→Z value) to accomodate for the wonky shield import
public class Rotation_shield : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //simple function makes power up sprite rotate
        transform.Rotate(new Vector3(0f, 0f, 125f) * Time.deltaTime/2);
    }
}
