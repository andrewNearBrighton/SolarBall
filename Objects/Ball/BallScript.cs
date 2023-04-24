using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public GameObject Ball ;
    float BallPosX;
    float BallPosY;
    public GameObject SunTransform;
    Vector3 GravityVector;
    public Transform BallTransform;
    public Rigidbody2D BallRigidBody;
 //   float distanceFromPlanet;
    float distanceFromSun;
   public float sunGravityForce;
 //   float planetGravityForce;
    
    //public GameObject[] PlanetsArray;
   // public Vector3 PlanetGravityVector;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        BallPosX = Ball.transform.position.x;
        BallPosY = Ball.transform.position.y;

        if (BallPosX >= 15)
        {
            Ball.transform.position = Ball.transform.position + new Vector3((BallPosX - 0.5f) * -2f, 0f, 0f);
        }

        if (BallPosX <= -15)
        {
            Ball.transform.position = Ball.transform.position + new Vector3((BallPosX + 0.5f) * -2f, 0f, 0f);
        }

        if (BallPosY >= 9.5)
        {
            Ball.transform.position = Ball.transform.position + new Vector3(0f, (BallPosY - 0.5f) * -2f, 0f);
        }

        if (BallPosY <= -9.5)
        {
            Ball.transform.position = Ball.transform.position + new Vector3(0f, (BallPosY + 0.5f) * -2f, 0f);
        }

        SunGravityPull();
      //  PlanetGravityPull();
      LimitSpeed();

    }

        void SunGravityPull()
    {
        GravityVector = BallTransform.position - SunTransform.transform.position;
        distanceFromSun = GravityVector.magnitude;
	    GravityVector.Normalize();
        GravityVector= GravityVector * sunGravityForce;
        GravityVector = GravityVector * (1/(distanceFromSun * distanceFromSun));
        BallRigidBody.AddForce(GravityVector * -1);
    }

    void LimitSpeed()
    {
        if (BallRigidBody.velocity.magnitude > 5)
        {
            BallRigidBody.velocity = BallRigidBody.velocity.normalized;
            BallRigidBody.velocity = BallRigidBody.velocity * 5;
        }
    }
 /*   void PlanetGravityPull()
    {
        PlanetsArray = GameObject.FindGameObjectsWithTag("Planet");
        foreach (GameObject planetPrefab in PlanetsArray)
        {
            PlanetGravityVector = BallTransform.position - planetPrefab.transform.position;
            distanceFromPlanet = PlanetGravityVector.magnitude;
            PlanetGravityVector.Normalize();
            PlanetGravityVector = PlanetGravityVector * planetGravityForce * (1 / (distanceFromPlanet * distanceFromPlanet));
            BallRigidBody.AddForce(PlanetGravityVector * -1);
        }
        
    }
    */
}
