using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    private int player1score = 0;
    private int player2score = 0;

    public Text Score1Counter, Score2Counter, Score3Counter, Score4Counter;
    // private int gameTimeOut;
    
    public int player1Health, player2Health, player3Health, player4Health;

    public int Player1Goal(int scoreToAdd)
    {
        player1score += scoreToAdd;
        Debug.Log(player1score.ToString());
        Score1Counter.text = player1score.ToString();
        return player1score;

    }

    public int Player2Goal(int scoreToAdd)
    {
        player2score += scoreToAdd;
        Score1Counter.text = player1score.ToString();
        return player2score;
    }

    public void ImpactDamage(Collider2D collision)
    {
        float Impact = collision.gameObject.GetComponent<PlayerMain>().GetShipImpactSpeed();
        player1Health = player1Health - (int) Impact;
        Debug.Log(Impact.ToString());
    }

    public static void SunBurn(float depth, Collider2D collisionObject)
    {
        int playerNumber = collisionObject.gameObject.GetComponent<PlayerMain>().playerNumber;
    }    

    public static void DestroyPlayer (Collider2D CollisionObject)
    {

    }

}
