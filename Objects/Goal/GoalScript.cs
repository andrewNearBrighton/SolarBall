using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    public GameObject Sun;
    public float orbitSpeed;
    public LogicScript Logic;
    public int goalNumber;


    void Start()
    {
        Sun = GameObject.FindGameObjectWithTag("Sun");
        Logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>(); 
    }

    public void SetGoalNumber(int newGoalNumber)
    {
        goalNumber = newGoalNumber;
    }
    void Update()
    {

        transform.RotateAround(Sun.transform.position, new Vector3(0, 0, 1), orbitSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D Collision)
    {
        if (Collision.gameObject.layer == 3)
        {

            Logic.AddPlayerScore(goalNumber);
            //Logic.Respawnball;
        }
    }

}
