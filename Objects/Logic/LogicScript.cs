using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    private int[] playersScore = new int[4] {0,0,0,0};
    private bool[] playerRespawning = new bool[4] {false,false,false,false};
    public int maxHealth = 100;

    public Text Score1Counter, Score2Counter, Score3Counter, Score4Counter;
    
    public int[] playersHealth = new int[4] {maxHealth,maxHealth,maxHealth,maxHealth};
    private float[] respawnTimers = new float[4] {0,0,0,0};
    GameObject[] = Players;

    void Start()
    {

    }

    void FixedUpdate()
    {
        foreach (bool player in playerRespawning)
        if (player == true;)
        {
//////////////////////////////////////////////////////////////////////////////////////
        }
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
        playersHealth[playerNumber] -= depth;
    }    

    public static void DestroyPlayer (GameObject DestroyedPlayer)
    {
        int destroyedPlayerNo = DestroyedPlayer.GetComponent<PlayerMain>().playerNumber;
        Destroy(DestroyedPlayer);
        playersScore[destroyedPlayerNo] -= 1;
        playerRespawning[destroyedPlayerNo] = true;
    }

    public static void ResetHealth(int playerNo)
    {
        playersHealth[playerNo] = maxHealth;
    }

}
