using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forceMove : MonoBehaviour
{
    public Rigidbody2D shipRigidBody;
    bool forwardInput;
    public float thrustForce = 2;
    float rotateInput;

    public float rotationSpeed = 2;

    public float maxVelocity;
    Vector3 currentVelocity;
    float currentVelocitySqrMag;

    public Transform shipTransform;

    Vector3 dummyVelocity;
    float dummyVelocitySqrMag;


    public float sunGravityForce;

    public Transform SunTransform;
    public Transform PlanetTransform;
    public float planetGravityForce;

    Vector3 GravityVector;
    float distanceFromSun;

    Vector3 PlanetGravityVector;
    float distanceFromPlanet;

    public SpriteRenderer SpriteRenderer;
    public Sprite IdleSprite;
    public Sprite Sprite1;
    public Sprite Sprite2;
    public Sprite Sprite3;
    int i = 0;




    // Start is called before the first frame update
    void Start()
    {

    }

    void FixedUpdate()
    { 
	    GetInput();
        ChangeSprite();
        PlanetGravityPull();
        SunGravityPull();


        currentVelocity = shipRigidBody.velocity;




        shipRigidBody.AddTorque (rotateInput * rotationSpeed * -1);



    }

  //gets forward + steering inputs, applies steering input
 
	void GetInput()
	{
        rotateInput = Input.GetAxis("Horizontal"); 
        forwardInput = Input.GetButton("Jump");
	        
        shipRigidBody.AddTorque (rotateInput * rotationSpeed * -1);
	
	if (forwardInput == true)
       		 {
            	OverMaxVelocity();
       		 }

	}


    // Limits top speed of ship, ship gets uncontrollably fast otherwise
    // Needs some work as currently unable to steer in when facing forward
    // at top speed.
    // Try getting thrust vector relative to velocity vector and using that to  rotate velocity vector.
    //

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

    // actually produces forward thrust

    void ForwardThrust()
    {
        shipRigidBody.AddForce(transform.up * thrustForce);

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
        PlanetGravityVector = shipTransform.position - PlanetTransform.position;
        distanceFromPlanet = PlanetGravityVector.magnitude;
        PlanetGravityVector.Normalize();
        PlanetGravityVector = PlanetGravityVector * planetGravityForce;
        PlanetGravityVector = PlanetGravityVector * (1 / (distanceFromPlanet * distanceFromPlanet * distanceFromPlanet));
        shipRigidBody.AddForce(PlanetGravityVector * -1);
    }


    //this one's just bad, you need to learn how to use animate properly.

    void ChangeSprite()
    {
        if (forwardInput ==  true)
        {
           animate();
        }
        else
        {
            SpriteRenderer.sprite = IdleSprite;
        }

       void animate()
        {

        if (i < 10)
             {SpriteRenderer.sprite = Sprite1;}
        if (i >= 10 && i < 20 )
             {SpriteRenderer.sprite = Sprite2;}
                if (i >= 20 && i < 30)
             {SpriteRenderer.sprite = Sprite2;}
        if (i>=30)
        {i=0;}
            i++;


        }
        
    }


}
