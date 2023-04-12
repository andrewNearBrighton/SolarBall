using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounterSpawner : MonoBehaviour
{
    public GameObject[] ScoreCounters;
    public int numberOfPlayers;

    public GameObject ScoreCounter;
    public float counterSpacing;

    public GameObject Logic;
    public GameObject CanvasObject;

    Vector3 counterTransform;
    


    public void SpawnCounters()
    {
        numberOfPlayers = Logic.GetComponent<LogicScript>().GetNumberOfPlayers();
        ScoreCounters = new GameObject [numberOfPlayers];

        for (int i=0; i < numberOfPlayers; i++)
        {
            counterTransform = new Vector3(1800,1000 - counterSpacing,0);
            GameObject NewScoreCounter = Instantiate(ScoreCounter,counterTransform,Quaternion.identity);
            NewScoreCounter.GetComponent<CounterScript>().SetCounterNumber(i);
            NewScoreCounter.transform.parent = CanvasObject.transform;
            Logic.GetComponent<LogicScript>().InitialisePlayersScores(i, NewScoreCounter);
            counterSpacing += counterSpacing;
        }



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
