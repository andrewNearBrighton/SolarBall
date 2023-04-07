using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    private int player1score,player2score,player3score,player4score = 0;
    public int maxHealth = 100;

    public Text Score1Counter, Score2Counter, Score3Counter, Score4Counter;
    // private int gameTimeOut;
    
    public int player1Health, player2Health, player3Health, player4Health =  maxHealth;
    GameObject[] = Players;

    void Start()
    {

    }

    void FixedUpdate()
    {
        
    }

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
        int  playerNumber = collisionObject.gameObject.GetComponent<PlayerMain>().playerNumber;
        switch playerNumber;
        {
            case 1:
            player1Health -= depth;
            break;
            case 2:
            player2Health -= depth;
            break;
            case 3:
            player3Health -= depth;
            break;
            case 4:
            player4Health -= depth;
            break;

        }
    }    

    public static void DestroyPlayer (Collider2D CollisionObject)
    {
        DestroyedPlayer = CollisionObject.gameObject;
        Destroy(DestroyedPlayer);
    }

}
