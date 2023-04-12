using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawnScript : MonoBehaviour
{
    public int noOfPlayers;
    public GameObject TargetPrefab1;
    public GameObject TargetPrefab2;
    public GameObject TargetPrefab3;
    public GameObject TargetPrefab4;
    Vector3 startPosition;
   public int distanceFromSun;
   public GameObject Sun;

   public GameObject NewGoal;
    SpriteRenderer sprite;

    public LogicScript Logic;
    void Start()
    {
         Logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>(); 
         noOfPlayers = Logic.GetNumberOfPlayers();
    
        for (int i=1; i<= noOfPlayers; i++)
        {

            if (i == 1)
             {
                startPosition = Vector3.left * distanceFromSun;
                NewGoal = Instantiate(TargetPrefab1, startPosition, Quaternion.identity);
                NewGoal.GetComponent<GoalScript>().SetGoalNumber(i-1);
            }

            if (i == 2)
            {
                startPosition = Vector3.right * distanceFromSun;  
                Instantiate(TargetPrefab2, startPosition, Quaternion.identity);
                NewGoal.GetComponent<GoalScript>().SetGoalNumber(i-1);
            }

            if (i == 3)
            {
                startPosition = Vector3.up * distanceFromSun;   
                Instantiate(TargetPrefab3, startPosition, Quaternion.identity);
                NewGoal.GetComponent<GoalScript>().SetGoalNumber(i-1);
            }

            if (i == 4)
            {
                startPosition = Vector3.down * distanceFromSun;   
                NewGoal = Instantiate(TargetPrefab4, startPosition, Quaternion.identity);
                NewGoal.GetComponent<GoalScript>().SetGoalNumber(i-1);
            }

        }    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
