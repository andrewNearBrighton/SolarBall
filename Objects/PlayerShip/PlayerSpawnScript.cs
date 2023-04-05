using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnScript : MonoBehaviour
{
    public int playerCount;
    public GameObject ShipPrefab;


    void Start()
    {
        var startingPosition = new Vector3(2,2,-1);
            Instantiate(ShipPrefab, startingPosition, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
