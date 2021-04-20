using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//written by Jason
//script is supposed to give power-ups a visual indicator for the player
public class Rotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //simple function makes power up sprite rotate
        transform.Rotate(new Vector3(0f, 125f, 0f) * Time.deltaTime);
    }
}
