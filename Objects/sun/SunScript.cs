using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunScript : MonoBehaviour
{


    public float rotationSpeed;
    public Transform Sun;
    public GameObject playerShips;
    public float killDepth;
    void Start()
    {
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
           Sun.Rotate(0, 0, rotationSpeed);
    }

    void OnTriggerStay (Collider2D collision)
        {
            if (collision.gameObject.layer == "playerShip")
            {  
                depthVector = Sun.Transform.Position - collision.gameObject.Transform.Position;
                depth = depthVector.Magnitude; 
                SunBurn(collision);
            }
        }

    void Sunburn (Collider2D collisionObject)
        {
            if (depth <= killDepth)
            {
                Logic.KillPlayer;
            }
            else
            {
                Logic.Sunburn(depth)
            }

        }

}
