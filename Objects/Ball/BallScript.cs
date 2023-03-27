using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public GameObject Ball ;
    float BallPosX;
    float BallPosY;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        BallPosX = Ball.transform.position.x;
        BallPosY = Ball.transform.position.y;

        if (BallPosX >= 10.5)
        {
            Ball.transform.position = Ball.transform.position + new Vector3((BallPosX - 0.5f) * -2f, 0f, 0f);
        }

        if (BallPosX <= -10.5)
        {
            Ball.transform.position = Ball.transform.position + new Vector3((BallPosX + 0.5f) * -2f, 0f, 0f);
        }

        if (BallPosY >= 6)
        {
            Ball.transform.position = Ball.transform.position + new Vector3(0f, (BallPosY - 0.5f) * -2f, 0f);
        }

        if (BallPosY <= -6)
        {
            Ball.transform.position = Ball.transform.position + new Vector3(0f, (BallPosY + 0.5f) * -2f, 0f);
        }

    }
}
