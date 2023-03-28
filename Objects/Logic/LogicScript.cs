using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicScript : MonoBehaviour
{
    private int player1score = 0;
    private int player2score = 0;
    // private int gameTimeOut;


    private int player1Goal(int scoreToAdd)
    {
        player1score += scoreToAdd;
        return player1score;
    }

    private int player2Goal(int scoreToAdd)
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
