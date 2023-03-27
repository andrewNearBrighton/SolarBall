using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public float timeOut;
    float currentTime;
    int currentTimeInt;
    public Text timerLabel;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        currentTimeInt = (int)currentTime;
        timerLabel.text = currentTimeInt.ToString();
    }
}
