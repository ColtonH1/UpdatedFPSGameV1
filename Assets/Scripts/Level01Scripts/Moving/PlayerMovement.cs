//Made by Colton Henderson

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.AI;
using Debug = UnityEngine.Debug;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    //Transform target;
    //NavMeshAgent agent;

    public static float speed = 12f; //speed
    public static float startingSpeed;
    public static float alteredSpeed;
    public static float currentSpeed;
    public float gravity = -9.81f; //gravity
    public float jumpHeight = 3f; //jumping
    public float crouchSpeed = 6f; //crouching speed

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private CharacterController characterController;
    public float height;


    Vector3 velocity; //gravity
    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        characterController = gameObject.GetComponent<CharacterController>();
        height = characterController.height;
        startingSpeed = speed;
        alteredSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        //currentSpeed = speed;

        currentSpeed = Player.GetNewSpeed();
        Debug.Log("Current Speed before running: " + currentSpeed);

        Jumping();
       
        currentSpeed = Running(currentSpeed);
        Debug.Log("Current Speed after running: " + currentSpeed);

        Moving(currentSpeed);

        if (Input.GetKey(KeyCode.C))
        {
            characterController.height = height * 0.75f;
            speed = startingSpeed * .5f;
        }
        if(!Input.GetKey(KeyCode.C))
        {
            characterController.height = height;
            speed = startingSpeed;
        }

    }

    private void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, Vector3.down, groundDistance + .1f))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

    }

    private void Moving(float currentSpeed)
    {
        //moving on x and z
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * currentSpeed * Time.deltaTime);

        controller.Move(velocity * Time.deltaTime);
    }

    private float Running(float currentSpeed)
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed *= 2;
        }
        else
        {
            currentSpeed = speed;
        }

        return currentSpeed;
    }

    private void Jumping()
    {
        //check if grounded to reset velocity when falling (or lack thereof)
        //isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
    }
    
    public static float GetSpeed()
    {
        return startingSpeed;
    }
}
