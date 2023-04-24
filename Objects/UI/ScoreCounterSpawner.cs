using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounterSpawner : MonoBehaviour
{
    public GameObject[] ScoreCounters;
    public int numberOfPlayers;

    public GameObject ScoreCounter;
    float counterSpacing;
    public float constCounterSpacing;

    public GameObject Logic;
    public GameObject CanvasObject;

    Vector3 counterTransform;
    


    public void SpawnCounters()
    {
        counterSpacing = constCounterSpacing;
        numberOfPlayers = Logic.GetComponent<LogicScript>().GetNumberOfPlayers();
        ScoreCounters = new GameObject [numberOfPlayers];

        for (int i=0; i < numberOfPlayers; i++)
        {
            counterTransform = new Vector3(1200,700 - counterSpacing,0);
            GameObject NewScoreCounter = Instantiate(ScoreCounter,counterTransform,Quaternion.identity);
            NewScoreCounter.GetComponent<CounterScript>().SetCounterNumber(i);
            NewScoreCounter.transform.parent = CanvasObject.transform;
            Logic.GetComponent<LogicScript>().InitialisePlayersScores(i, NewScoreCounter);
            counterSpacing += constCounterSpacing;
        }



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
