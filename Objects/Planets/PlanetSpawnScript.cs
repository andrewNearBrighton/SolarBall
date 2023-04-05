
using UnityEngine;


public class PlanetSpawnScript : MonoBehaviour
{
    public GameObject PlanetPrefab;
    public int noOfPlanets;
    public int lowerBoundSpawnLocation;
    public int upperBoundSpawnLocation;
    int xSpawn;
    int ySpawn;
    void Start()
    {
        noOfPlanets = (int)Random.Range(2, 6);
        
        for (int i=1; i<= noOfPlanets; i++)
        {
        
        xSpawn = (int) Random.Range(lowerBoundSpawnLocation,upperBoundSpawnLocation);
        ySpawn = (int) Random.Range(lowerBoundSpawnLocation, upperBoundSpawnLocation);
        var startingPosition = new Vector3(xSpawn, ySpawn, -1);

        Instantiate(PlanetPrefab, startingPosition, Quaternion.identity);
        }
    }

}