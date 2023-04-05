
using UnityEngine;


public class PlayerSpawn : MonoBehaviour
{
    public GameObject PlayerShipPrefab;
    public int noOfPlayers;

    void Start()
    {

        
        for (int playerNo=1; i<= noOfPlayers; playerNo++)
        {
        switch (playerNo)
        {
            case 1:
            startingPosition = new Vector3(2,-2,0);
            break;
            case 2:
            startingPosition = new Vector3(-2,2,0);
            break;
            case 3:
            startingPosition = new Vector3(2,2,0);
            break;
            case 4:
            startingPosition = new Vector3(-2,-2,0);
            break;
            default:
            startingPosition = new Vector3(0,0,0);
        }

        GameObject newPlayer = Instantiate(PlayerShipPrefab, startingPosition, Quaternion.identity);
        forceMove.SetPlayerNumber(playerNo)
        }
    }

}