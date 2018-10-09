using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorChanger : MonoBehaviour
{
    //The ship sprite variable
    public SpriteRenderer shipRenderer;
    //Decides if the transparency should go up or down
    bool colorPulse;
    //The transparency of the ship
    public float transparency;
    //The rgb values for the ship
    float red;
    float blue;
    float green;
    // Use this for initialization
    void Start()
    {
        //Makes it so transparency will decrease in the start
        colorPulse = true;
        //Sets the transparency to full in the start
        transparency = 1;
        //Makes it so the ship is white in the beginning
        red = 1;
        green = 1;
        blue = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //Changes the ships color each frame according the specified rgba values
        shipRenderer.color = new Color(red, green, blue, transparency);
        //If colorPulse is true the transperancy gets reduced every frame. If the transperancy is below 0.5 it turns of colorPulse
            if (colorPulse == true)
        {
            transparency = transparency - 0.01f;
            if (transparency <= 0.5)
            {
                colorPulse = false;
            }
        }
        //If colorPulse is false the transparency gets increased every frame until it is 1 then it switches colorPulse to false
        if (colorPulse == false)
        {
            transparency = transparency + 0.01f;
            if (transparency >= 1)
            {
                colorPulse = true;
            }

        }

        //Makes it so when you hold "D" red and green get the value 0 and blue gets 1. So that blue is the only color
        if (Input.GetKey(KeyCode.D))
        {
            red = 0;
            green = 0;
            blue = 1;
        }
        //Makes it so when you hold "A" red and blue get the value 0 and green gets 1. So that green is the only color
        if (Input.GetKey(KeyCode.A))
        {
            red = 0;
            green = 1;
            blue = 0;
        }
        //When Space bar is pressed the ship gets a random color
        if (Input.GetKeyDown(KeyCode.Space))
        {
            red = Random.Range(0f, 1f);
            green = Random.Range(0f, 1f);
            blue = Random.Range(0f, 1f);
        }




    }
}
