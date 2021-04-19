/*
 * Made by Colton Henderson
 * This script shows the green firing line when debugging
 * It shows up in the scene mode when play mode is on
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayViewer : MonoBehaviour
{
    public float weaponRange = 50f;

    private Camera fpsCam;

    void Start()
    {
        fpsCam = GetComponentInParent<Camera>(); //find camera needed
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lineOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0)); //where line begins
        Debug.DrawRay(lineOrigin, fpsCam.transform.forward * weaponRange, Color.green); //shows firing line in non-play mode
    }
}
