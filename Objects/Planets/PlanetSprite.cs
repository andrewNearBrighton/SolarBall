using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSprite : MonoBehaviour
{
    public GameObject Planet;

    public Sprite[] planetSprites = new Sprite[9];

    public SpriteRenderer PlanetSpriteRenderer;

    int spriteChoice;

    public float spinSpeed;
    // Start is called before the first frame update
    void Start()
    {


        spriteChoice = Random.Range(0,8);

        PlanetSpriteRenderer.sprite = planetSprites[spriteChoice];

    }

    // Update is called once per frame
    void Update()
    {
        Planet.transform.Rotate(0, 0, spinSpeed*Time.deltaTime);
    }
}
