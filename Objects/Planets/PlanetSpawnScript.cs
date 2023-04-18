
using UnityEngine;

public class PlanetSpawnScript : MonoBehaviour
{
    public GameObject PlanetPrefab;
    public int noOfPlanets;
    public int lowerBoundSpawnLocation;
    public int upperBoundSpawnLocation;
    
    float xSpawn;
    float startingAngle;
    float distanceFromSun;

    Vector3 startingPosition = new Vector3(1,0,0);

    void Start()
    {
        noOfPlanets = (int)Random.Range(2, 6);
        
        for (int i=1; i<= noOfPlanets; i++)
        {
        


    
        GameObject NewPlanet = Instantiate(PlanetPrefab, startingPosition, Quaternion.identity);

        distanceFromSun = Random.Range(lowerBoundSpawnLocation,upperBoundSpawnLocation) * 2;
        startingAngle = Random.Range(0,359);
        NewPlanet.transform.position = NewPlanet.transform.position * distanceFromSun;
        NewPlanet.transform.position = Quaternion.Euler(0,0,startingAngle) * NewPlanet.transform.position;
        NewPlanet.transform.localScale = NewPlanet.transform.localScale * Random.Range (3,8) / 10;
        }
    }

}