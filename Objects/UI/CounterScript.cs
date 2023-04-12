using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterScript : MonoBehaviour
{
    public int counterNumber;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCounterNumber(int newGoalNumber)
    {
        counterNumber = newGoalNumber;
    }
    public int GetCounterNumber()
    {
        return counterNumber;
    }
}

