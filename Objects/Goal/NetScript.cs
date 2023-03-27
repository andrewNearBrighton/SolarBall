using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetScript : MonoBehaviour
{
    public GameObject Sun;
    public float orbitSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(Sun.transform.position, new Vector3(0, 0, 1), orbitSpeed * Time.deltaTime);
    }
}
