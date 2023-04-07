using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnScript : MonoBehaviour
{
    public int playerCount;
    public GameObject ShipPrefab;
    Vector3 startingPosition;

        void Start()
        {
            Debug.Log("start");
            for (int playerNo = 0; playerNo <= (playerCount-1); playerNo++)
            {
                SpawnPlayer(playerNo);


        }
    }

    SpawnPlayer()
    {
         switch (playerNo)
            {
                case 0:
                startingPosition = new Vector3(2,-2,-1);
                break;
                case 1:
                startingPosition = new Vector3(-2,2,-1);
                break;
                case 2:
                startingPosition = new Vector3(2,2,-1);
                break;
                case 3:
                startingPosition = new Vector3(-2,-2,-1);
                break;
                default:
                startingPosition = new Vector3(0,0,-1);
                break;
            }

            Instantiate(ShipPrefab, startingPosition, Quaternion.identity);
            Debug.Log ("Player Spawned");
            LogicScript.ResetHealth(playerNo);
    }
}