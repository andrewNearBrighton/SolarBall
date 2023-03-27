using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicScript : MonoBehaviour
{
    private int player1score;
    private int player2score;
    // private int gameTimeOut;


    int player1Goal()
    {
        player1score += 1;
        return player1score;
    }

    int player2Goal()
    {
        player2score += 1;
        return player2score;
    }
    /*
    bool timeOut ()
    {
        
    }


    */

    

}
