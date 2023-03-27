using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunScript : MonoBehaviour
{


    public float rotationSpeed;
    public Transform Sun;

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Sun.Rotate(0, 0, rotationSpeed);
    }

}
