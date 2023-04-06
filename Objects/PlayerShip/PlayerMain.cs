
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : MonoBehaviour
{
    public Rigidbody2D shipRigidBody;
    float forwardInput;
    public float thrustForce = 2;
    public float rotationSpeed = 2;
    public float maxVelocity;
    public Transform shipTransform;
    Vector3 dummyVelocity;
    public float sunGravityForce;
    public GameObject SunTransform;
    public float planetGravityForce, impactMagnitude;
    Vector3 GravityVector;
    float distanceFromSun, distanceFromPlanet, dummyVelocitySqrMag, rotateInput;
    Vector3 PlanetGravityVector;
    public SpriteRenderer SpriteRenderer;
    public Sprite IdleSprite, Sprite1, Sprite2, Sprite3;
    public GameObject[] PlanetsArray;
    public int playerHealth;
    public int playerNumber;


    int i = 0;




    // Start is called before the first frame update
    void Start()
    {

    }

    void FixedUpdate()
    { 
        SetShipImpactSpeed();
	    GetInput();
        ChangeSprite();
        PlanetGravityPull();
        SunGravityPull();
    }

  //gets forward + steering inputs, applies steering input
 
	void GetInput()
	{
        rotateInput = Input.GetAxis("Horizontal"); 
        forwardInput = Input.GetAxis("Vertical");
	        
        shipRigidBody.AddTorque (rotateInput * rotationSpeed * -1);
	
	if (forwardInput > 0.1f)
       		 {
            	ForwardThrust();
       		 }

	}

    void ForwardThrust()
    {
        shipRigidBody.AddForce(transform.up * thrustForce);
	if (shipRigidBody.velocity.magnitude > 6)
	{
		shipRigidBody.velocity = shipRigidBody.velocity / shipRigidBody.velocity.magnitude;
		shipRigidBody.velocity = shipRigidBody.velocity * 6;
	}

    }

    // gets direction to sun, normalises, applies inverse square and adds force 

    void SunGravityPull()
    {
        SunTransform = GameObject.FindGameObjectWithTag("Sun");
        GravityVector = shipTransform.position - SunTransform.transform.position;
        distanceFromSun = GravityVector.magnitude;
	    GravityVector.Normalize();
        GravityVector= GravityVector * sunGravityForce;
        GravityVector = GravityVector * (1/(distanceFromSun * distanceFromSun));
        shipRigidBody.AddForce(GravityVector * -1);
    }

    void PlanetGravityPull()
    {
        PlanetsArray = GameObject.FindGameObjectsWithTag("Planet");
        foreach (GameObject planetPrefab in PlanetsArray)
        {
            PlanetGravityVector = shipTransform.position - planetPrefab.transform.position;
            distanceFromPlanet = PlanetGravityVector.magnitude;
            PlanetGravityVector.Normalize();
            PlanetGravityVector = PlanetGravityVector * planetGravityForce * (1 / (distanceFromPlanet * distanceFromPlanet));
            shipRigidBody.AddForce(PlanetGravityVector * -1);
        }
        
    }


    //this one's just bad, you need to learn how to use animate properly.

    void ChangeSprite()
    {
        if (forwardInput > 0.5f)
        {
            animate();
        }
        else
        {
            SpriteRenderer.sprite = IdleSprite;
        }

        void animate()
        {
            if (i < 100)
            { SpriteRenderer.sprite = Sprite1; }
            if (i >= 100 && i < 200)
            { SpriteRenderer.sprite = Sprite2; }
            if (i >= 200 && i < 300)
            { SpriteRenderer.sprite = Sprite3; }
            if (i >= 300)
            { i = 0; }
            i++;
       	}

 	   }
        
        public void  SetShipImpactSpeed()
        {
            impactMagnitude = shipRigidBody.velocity.magnitude;  
        }
        
        public float GetShipImpactSpeed()
        {
		    return impactMagnitude;
	    }

        public void SetPlayerNumber(int PlayerNumber)
        {
            playerNumber = PlayerNumber;
        }

        public int GetPlayerNumber()
        {
            return playerNumber;
        }
 

}