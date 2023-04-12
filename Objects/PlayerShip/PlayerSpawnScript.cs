using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnScript : MonoBehaviour
{
    public int playerCount;
    public GameObject ShipPrefab;
    Vector3 startingPosition;
    Vector4 Color;

    public GameObject Logic;

        void Start()
        {
            Logic = GameObject.FindGameObjectWithTag("Logic");
            playerCount = Logic.GetComponent<LogicScript>().GetNumberOfPlayers();


            for (int playerNo = 0; playerNo <= (playerCount-1); playerNo++)
            {
                SpawnPlayer(playerNo);


        }
    }

    public void SpawnPlayer(int playerNo)
    {
         switch (playerNo)
            {
                case 0:
                startingPosition = new Vector3(2,-2,-1);
                Color = new Vector4 (255,255,255,255);
                break;
                case 1:
                startingPosition = new Vector3(-2,2,-1);
                Color = new Vector4 (0,255,0,255);
                break;
                case 2:
                startingPosition = new Vector3(2,2,-1);
                Color = new Vector4 (255,0,0,255);
                break;
                case 3:
                startingPosition = new Vector3(-2,-2,-1);
                Color = new Vector4 (0,255,0,255);
                break;
                default:
                startingPosition = new Vector3(0,0,-1);
                break;
            }

            GameObject NewPlayer = Instantiate(ShipPrefab, startingPosition, Quaternion.identity);
            NewPlayer.GetComponentInChildren<PlayerMain>().SetPlayerNumber(playerNo);
            NewPlayer.GetComponentInChildren<SpriteRenderer>().color = Color;
            Debug.Log ("Player Spawned");
            LogicScript.ResetHealth(playerNo);
    }
}