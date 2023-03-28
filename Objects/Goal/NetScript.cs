using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetScript : MonoBehaviour
{
    public GameObject Sun;
    public float orbitSpeed;
    public RigidBody2d Goal;
    public GameObject Logic;

    // Start is called before the first frame update
    void Start()
    {
        Logic = GameObject.FindgameObjectWithTag("Logic");
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(Sun.transform.position, new Vector3(0, 0, 1), orbitSpeed * Time.deltaTime);
        
        
        private void OnCollisionEnter2D()
        if colliding object layer == 3
        {
          Logic.Script.LogicScript.Player1Goal(1);
          
        }
    }
}
