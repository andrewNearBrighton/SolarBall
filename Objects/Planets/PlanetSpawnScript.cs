
using UnityEngine;


public class PlanetSpawnScript : MonoBehaviour
{
    public GameObject PlanetPrefab;
    private int noOfPlanets;

    void Start()
    {
        noOfPlanets = (int)Random.Range(1, 6);
        
        for (int i=1; i<= noOfPlanets; i++)
        {
        var startingPosition = new Vector3(Random.Range(-6f, 6f), Random.Range(-6f, 6f), 0);

        Instantiate(PlanetPrefab, startingPosition, Quaternion.identity);
        }
    }

}