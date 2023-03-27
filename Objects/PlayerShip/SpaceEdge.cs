using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceEdge : MonoBehaviour
{
    public GameObject playerShip;
    float playerPosX;
    float playerPosY;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        playerPosX = playerShip.transform.position.x;
        playerPosY = playerShip.transform.position.y;

        if (playerPosX >= 10.5)
        {
            playerShip.transform.position = playerShip.transform.position + new Vector3((playerPosX-0.5f) * -2f,0f,0f);
        }

        if (playerPosX <= -10.5)
        {
            playerShip.transform.position = playerShip.transform.position + new Vector3((playerPosX + 0.5f) * -2f, 0f, 0f);
        }

        if (playerPosY >= 6)
        {
            playerShip.transform.position = playerShip.transform.position + new Vector3(0f,(playerPosY - 0.5f) * -2f, 0f);
        }

        if (playerPosY <= -6)
        {
            playerShip.transform.position = playerShip.transform.position + new Vector3(0f,(playerPosY + 0.5f) * -2f, 0f);
        }

    }
}
