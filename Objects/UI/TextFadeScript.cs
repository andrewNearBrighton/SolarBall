using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFadeScript : MonoBehaviour
{
    public Text YouDied;
    public Color clear;
    public Color Red;

  
    void Start()
    {
        YouDied.color = clear;
    }

    // Update is called once per frame
    void Update()
    {
        YouDied.color = Color.Lerp(YouDied.color, Red, 1f * Time.deltaTime);
    }
}
