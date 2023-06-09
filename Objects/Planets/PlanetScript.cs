using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetScript : MonoBehaviour
{



    
    public GameObject Logic;
    public GameObject Sun;
    public GameObject Planet;
    public float orbitSpeed;
    float distanceFromSun;
    Vector3 sunVector;


    // Start is called before the first frame update
    void Start()
    {
    Sun = GameObject.FindGameObjectWithTag("Sun");
    Logic =  GameObject.FindGameObjectWithTag("Logic");
    }

    // Update is called once per frame
    void Update()
    {
        sunVector = Planet.transform.position - Sun.transform.position;
        distanceFromSun = sunVector.magnitude;
        transform.RotateAround(Sun.transform.position, new Vector3 (0,0,1), (orbitSpeed/distanceFromSun) * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D CollisionObject)
    {
	if (CollisionObject.gameObject.tag == "Player")
	{
		Logic.GetComponent<LogicScript>().ImpactDamage(CollisionObject.collider);
        Debug.Log("Collision");
	}
    }
}
