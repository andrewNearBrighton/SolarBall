using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    public int numberOfStars;
    public GameObject Star;
    Vector4 NewColor;
    Color starColor;

    float GreenValue;
    float RedValue;
    float BlueValue;
    public SpriteRenderer StarSpriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        for (int i =1; i <= numberOfStars; i++)
        {
            GreenValue = (float) (Random.Range(50,99))/100;
            RedValue = (float) (Random.Range(50,99))/100;
            BlueValue = (float) (Random.Range(50,99))/100;
            NewColor = new Vector4(RedValue,GreenValue,BlueValue,0.9f);
            starColor = NewColor;
            GenerateStars();
        }
    }

    public void GenerateStars()
    {
        GameObject NewStar = Instantiate(Star, new Vector3(Random.Range(-10,10),Random.Range(-8,8),0),Quaternion.Euler(0,0,Random.Range(0,179)));
        StarSpriteRenderer = NewStar.GetComponent<SpriteRenderer>();
        StarSpriteRenderer.color = NewColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
