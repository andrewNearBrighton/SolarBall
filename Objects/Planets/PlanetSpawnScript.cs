
using UnityEngine;


public class PlanetSpawnScript : MonoBehaviour
{
    public GameObject PlanetPrefab;


    void Start()
    {
        var startingPosition = new Vector3(Random.Range(-6f, 6f), Random.Range(-6f, 6f), 0);

        Instantiate(PlanetPrefab, startingPosition, Quaternion.identity);
    }

}