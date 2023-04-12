using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunScript : MonoBehaviour
{


    public float rotationSpeed;
    public Transform Sun;
    public GameObject playerShips;
    public float killDepth;
    public float depth;
    void Start()
    {
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
           Sun.Rotate(0, 0, rotationSpeed);
    }

    void OnTriggerStay2D (Collider2D collisionObject)
        {
            if (collisionObject.gameObject.tag == "playerShip")
            {  
                Vector3 depthVector = Sun.position - collisionObject.gameObject.transform.position;
                depth = depthVector.magnitude; 
                Sunburn(collisionObject, depth);
            }
        }

    void Sunburn (Collider2D collisionObject, float _depth)
        {
            if (_depth <= killDepth)
            {
                GameObject DestroyedPlayer = collisionObject.gameObject;
                LogicScript.DestroyPlayer(DestroyedPlayer);
            }
            else
            {
                LogicScript.SunBurn(depth, collisionObject);
            }

        }

}
