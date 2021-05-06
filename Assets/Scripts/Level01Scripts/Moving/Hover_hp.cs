using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//written by Jason
//script is supposed to give power-ups a visual indicator for the player
// this variant of the script is for the shield sprite because for some reason it imported at a -90 degree angle on the 
//X axis and I'm not sure how to fix it.
public class Hover_hp : MonoBehaviour
{
    //defines how fast sprite hovers
    public float speed = 0.6f;
    bool change = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(change){
            moveUp();
        }
        if(!change)
        {
            moveDown();
        }
        //defines when sprite will hover back down
        if (transform.position.y >= 1.7f){
            change = false;
        }
        if (transform.position.y <= .85f){
            change = true;
        }
    }
    void moveUp(){
        transform.Translate(0,speed*Time.deltaTime,0);
    }
    void moveDown(){
        transform.Translate(0,-speed*Time.deltaTime,0); 
    }
}
