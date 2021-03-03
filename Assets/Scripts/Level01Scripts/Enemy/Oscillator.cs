using System.Collections;
using System.Collections.Generic;
using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

[DisallowMultipleComponent]
public class Oscillator : MonoBehaviour
{
    /*//change in x
    [SerializeField] int maxRight = 7;
    [SerializeField] int minLeft = -7;
    [SerializeField] bool changeX = false;
    [SerializeField] bool randChangeX = true;
    [Range(0, 1f)] [SerializeField] float movementFactorX;

    //change in y
    [SerializeField] int maxHeight = 7;
    [SerializeField] int minHeight = -7;
    [SerializeField] bool changeY = false;
    [SerializeField] bool randChangeY = true;
    [Range(0, 1f)] [SerializeField] float movementFactorY;

    //change in z
    [SerializeField] int maxForth = 7;
    [SerializeField] int minBack = -7;
    [SerializeField] bool changeZ = false;
    [SerializeField] bool randChangeZ = true;
    [Range(0, 1f)] [SerializeField] float movementFactorZ;*/

    [SerializeField] float minMF, maxMF;
    [SerializeField] int x1, x2, y1, y2, z1, z2;
    [SerializeField] Vector3 movementVector = new Vector3(10f, 10f, 10f);
    [SerializeField] float period = 2f;
    [Range(0, 1f)] [SerializeField] float movementFactor;


    Vector3 startingPos;

    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
        /*if (randChangeX)
        {
            System.Random rndX = new System.Random();
            int randNum = rndX.Next(1, 20);
            movementFactorX = randNum * .01f;
        }
        if (randChangeY)
        {
            System.Random rndY = new System.Random();
            int randNum = rndY.Next(1, 20);
            movementFactorY = randNum * .01f;
        }
        if (randChangeZ)
        {
            System.Random rndZ = new System.Random();
            int randNum = rndZ.Next(1, 20);
            movementFactorZ = randNum * .01f;
        }*/
    }
    /*
    private void RandomMoveFactor()
    {
        System.Random rnd = new System.Random();
        int randNum = rnd.Next(1, 20);
        movementFactorX = randNum * .01f;
    }*/

    // Update is called once per frame
    void Update()
    {
        float move = movementFactor;
        float cycles = Time.time / period;

        const float tau = Mathf.PI * 2;
        float rawSinWave = Mathf.Sin(cycles * tau);

        movementFactor = rawSinWave / 2f + .05f;
        Vector3 offset = movementFactor * movementVector;
        transform.position = startingPos + offset;

        if(movementFactor > maxMF)
        {
            transform.rotation = Quaternion.Euler(new Vector3(x1, y1, z1));
        }
        if(movementFactor < minMF)
        {
            transform.rotation = Quaternion.Euler(new Vector3(x2, y2, z2));
        }
            
        //Debug.Log("MF is " + move);

    }/*
        if(changeX)
            ChangeX();
        if (changeY)
            ChangeY();
        if (changeZ)
            ChangeZ();
    }

    private void ChangeX()
    {
        transform.Translate(Vector3.right * movementFactorX, Space.World);

        if (transform.position.x >= maxRight || transform.position.x <= minLeft)
        {
            movementFactorX *= -1;
        }
    }

    private void ChangeY()
    {
        transform.Translate(Vector3.up * movementFactorY, Space.World);

        if (transform.position.y >= maxHeight || transform.position.y <= minHeight)
        {
            movementFactorY *= -1;
        }
    }

    private void ChangeZ()
    {
        transform.Translate(Vector3.forward * movementFactorY, Space.World);

        if (transform.position.z >= maxForth || transform.position.z <= minBack)
        {
            movementFactorY *= -1;
        }
    }*/

}
