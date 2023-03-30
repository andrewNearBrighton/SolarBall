using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    private int player1score = 0;
    private int player2score = 0;

    public Text Score1Counter, Score2Counter;
    // private int gameTimeOut;


    public int Player1Goal(int scoreToAdd)
    {
        player1score += scoreToAdd;
        Debug.Log(player1score);
        Score1Counter.text = player1score.ToString();
        return player1score;

    }

    public int Player2Goal(int scoreToAdd)
    {
        player2score += scoreToAdd;
        return player2score;
    }
    
    
    /*
    bool timeOut ()
    {
        
    }


    */

    

}
