
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : MonoBehaviour
{
    public Rigidbody2D shipRigidBody;
    bool forwardInput;
    bool rightInput;
    bool leftInput;
 //   bool boostInput;
    public float thrustForce = 2;
    public float rotationSpeed = 2;
    public float maxVelocity;
    public Transform shipTransform;
    public float sunGravityForce;
    public GameObject SunTransform;
    public float planetGravityForce, impactMagnitude;
    Vector3 GravityVector;
    float distanceFromSun, distanceFromPlanet, dummyVelocitySqrMag, rotateInput;
    Vector3 PlanetGravityVector;
    //public SpriteRenderer SpriteRenderer;
    //public Sprite IdleSprite, Sprite1, Sprite2, Sprite3;
    public GameObject[] PlanetsArray;
    public int playerNumber;
    public string forwardButton;
    public string leftButton;
    public string rightButton;
    public ParticleSystem ExhaustParticleSystem;




    // Start is called before the first frame update
    // sets controls for different players
    // player 1 is default
    void Start()
    {
        switch (playerNumber)
        {

            case 1:
            forwardButton = "up";
            leftButton = "left";
            rightButton = "right";
            break;
            case 2:
            forwardButton = "joypad1w";
            leftButton = "joypad1a";
            rightButton = "joypad1d";
            break;
            case 3:
            forwardButton = "joypad2w";
            leftButton = "joypad2a";
            rightButton = "joypad";
            break;
            default:
            forwardButton = "w";
            leftButton = "a";
            rightButton = "d";
            break;
        }
    }

    void FixedUpdate()
    { 
        SetShipImpactSpeed();
	    GetInput();
      //  ChangeSprite();
        SunGravityPull();
        PlanetGravityPull();
    }
 
	void GetInput()
	{

	        forwardInput = Input.GetButton(forwardButton);
            leftInput = Input.GetButton(leftButton);
            rightInput = Input.GetButton(rightButton);


        if (leftInput ==true)
        {
            shipRigidBody.AddTorque (rotationSpeed * 1);
        }
        if (rightInput == true)
        {
            shipRigidBody.AddTorque (rotationSpeed * -1);
        }

	    if (forwardInput == true)
       	{
            ForwardThrust();
            var emission = ExhaustParticleSystem.emission;
            emission.enabled = true;
        }
        else
        {
            var emission = ExhaustParticleSystem.emission;
            emission.enabled = false; 
        }

	}

    void ForwardThrust()
    {
        shipRigidBody.AddForce(transform.up * thrustForce);
	    if (shipRigidBody.velocity.magnitude > maxVelocity)
	    {
		    shipRigidBody.velocity = shipRigidBody.velocity / shipRigidBody.velocity.magnitude;
		    shipRigidBody.velocity = shipRigidBody.velocity * maxVelocity;
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
/*
    void ChangeSprite()
    {
        if (forwardInput == true)
        {
            SpriteRenderer.sprite = Sprite1; 
        }
        else
        {
            SpriteRenderer.sprite = IdleSprite;
        }

 	}     

    */   
        
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

        /*public OnCollisionEnter2D()
        {
            play collision sound
        }
 */

}