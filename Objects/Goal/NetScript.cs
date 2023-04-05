using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetScript : MonoBehaviour
{
    public GameObject Sun;
    public float orbitSpeed;
    public LogicScript Logic;

    // Start is called before the first frame update
    void Start()
    {
        Sun = GameObject.FindGameObjectWithTag("Sun");
        Logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(Sun.transform.position, new Vector3(0, 0, 1), orbitSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D Collision)
    {
        if (Collision.gameObject.layer == 3)
        {
            Logic.Player1Goal(1);
        }
    }
}