using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    private static int[] playersScore = new int[4] {0,0,0,0};
    private static bool[] playerRespawning = new bool[4] {false,false,false,false};
    public static int maxHealth = 100;

    
    public static int[] playersHealth = new int[4] {maxHealth,maxHealth,maxHealth,maxHealth};
    public static float[] respawnTimers = new float[4] {0,0,0,0};
    public int numberOfPlayers;
    public int scoreToAdd;
    public GameObject [] ScoreCounters;
    public GameObject ScoreSpawner;

    void Start()
    {
        ScoreCounters = new GameObject[numberOfPlayers]; 
        ScoreSpawner.GetComponent<ScoreCounterSpawner>().SpawnCounters();
    }
    public void InitialisePlayersScores(int playerNo, GameObject NewCounter)
    {
        ScoreCounters[playerNo] = NewCounter;
    }

    public int GetNumberOfPlayers()
    {
        return numberOfPlayers;
    }
 /*   void FixedUpdate()

    

    
        foreach (bool player in playerRespawning)
        if (player == true)
        {
//////////////////////////////////////////////////////////////////////////////////////
        }
    }

*/
    

    public void ImpactDamage(Collider2D collision)
    {
        float Impact = collision.gameObject.GetComponent<PlayerMain>().GetShipImpactSpeed();
        int playerNo = collision.gameObject.GetComponent<PlayerMain>().GetPlayerNumber();
        playersHealth[playerNo] -= (int) Impact;
        int health = playersHealth[playerNo];
    }

    public static void SunBurn(float depth, Collider2D collisionObject)
    {
        int  playerNumber = collisionObject.gameObject.GetComponentInChildren<PlayerMain>().playerNumber;
        playersHealth[playerNumber] -= (int) depth;
    }    

    public static void DestroyPlayer (GameObject DestroyedPlayer)
    {
        int destroyedPlayerNo = DestroyedPlayer.GetComponentInChildren<PlayerMain>().playerNumber;
        Destroy(DestroyedPlayer);
        playersScore[destroyedPlayerNo] -= 1;
        playerRespawning[destroyedPlayerNo] = true;
    }

    public static void ResetHealth(int playerNo)
    {
        playersHealth[playerNo] = maxHealth;
    }

    public void AddPlayerScore(int playerNumber)
    {
        playersScore[playerNumber] +=scoreToAdd;
        ScoreCounters[playerNumber].GetComponent<Text>().text = playersScore[playerNumber].ToString();
    }

}
