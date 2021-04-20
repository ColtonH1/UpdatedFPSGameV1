using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float speed;
    public Vector3 axis;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(axis * speed * Time.deltaTime);
    }
}
