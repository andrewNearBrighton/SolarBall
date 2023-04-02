
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forceMove : MonoBehaviour
{
    public Rigidbody2D shipRigidBody;
    float forwardInput;
    public float thrustForce = 2;
    public float rotationSpeed = 2;
    public float maxVelocity;
    public Transform shipTransform;
    Vector3 dummyVelocity;
    public float sunGravityForce;
    public Transform SunTransform;
    public float planetGravityForce, impactMagnitude;
    Vector3 GravityVector;
    float distanceFromSun, distanceFromPlanet, dummyVelocitySqrMag, rotateInput;
    Vector3 PlanetGravityVector;
    public SpriteRenderer SpriteRenderer;
    public Sprite IdleSprite, Sprite1, Sprite2, Sprite3;
    public GameObject[] PlanetsArray;
    public int playerHealth;


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


    // Limits top speed of ship, ship gets uncontrollably fast otherwise
    // Needs some work as currently unable to steer in when facing forward
    // at top speed.
    // Try getting thrust vector relative to velocity vector and using that to  rotate velocity vector.
    //
/*
    void OverMaxVelocity()
    {
        dummyVelocity = currentVelocity;
        dummyVelocity = dummyVelocity + (transform.up * thrustForce);
        dummyVelocitySqrMag = dummyVelocity.sqrMagnitude;
        
        if (dummyVelocitySqrMag < maxVelocity)
        {
            ForwardThrust();
        }
    }
*/
    // actually produces forward thrust

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
        GravityVector = shipTransform.position - SunTransform.position;
        distanceFromSun = GravityVector.magnitude;
	    GravityVector.Normalize();
        GravityVector= GravityVector * sunGravityForce;
        GravityVector = GravityVector * (1/(distanceFromSun * distanceFromSun * distanceFromSun));
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
            PlanetGravityVector = PlanetGravityVector * planetGravityForce * (1 / (distanceFromPlanet * distanceFromPlanet * distanceFromPlanet));
            shipRigidBody.AddForce(PlanetGravityVector * -1);
            Debug.Log(planetPrefab.transform.position.x);
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
        
        void  SetShipImpactSpeed()
         {
                impactMagnitude = shipRigidBody.velocity.magnitude;  
         }
        
        float  GetShipImpactSpeed()
         {
		 return impactMagnitude;
	 }
 

}