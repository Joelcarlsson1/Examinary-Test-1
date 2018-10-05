using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipMovement : MonoBehaviour
{
    //The ships left turn speed
    float leftRotationSpeed;
    //The ships base turn speed
    public float baseRotationSpeed;
    //Player assigned ship speed
    public float baseSpeed;
    //The current ship speed
    float forwardSpeed;
    //The ship sprite variable
    public SpriteRenderer shipRenderer;
    //The amount of time while in game
    public int timer;
    
    
    
    // Use this for initialization
    void Start()
    {
        //Sets the ship's current speed to the player assigned ship speed
        forwardSpeed = baseSpeed;
        leftRotationSpeed = baseRotationSpeed / 2;
    }

    // Update is called once per frame
    void Update()
    {
        //Makes the ship go forward all the time based on the given speed, in real time
        transform.Translate(forwardSpeed * Time.deltaTime, 0f, 0f, Space.Self);
        //Makes it so when you hold "D" the ship rotates to the right and the ship turns blue
        if (Input.GetKey(KeyCode.D))
        {       
                transform.Rotate(0f, 0f, -baseRotationSpeed * Time.deltaTime);
            
            shipRenderer.color = new Color(0f, 0f, 1f, 1f);
        }
        //Makes it so when you hold "A" the ship rotates to the left and the ship turns green
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0f, 0f, leftRotationSpeed * Time.deltaTime);
            shipRenderer.color = new Color(0f, 1f, 0f, 1f);
        }
        //Makes it so when you hold "S" the ship speed halfs
        if (Input.GetKey(KeyCode.S))
        {
            forwardSpeed = baseSpeed / 2;
        }
        //When the "S" key is up the current ship speed is set to the player assigned speed
        if (Input.GetKeyUp(KeyCode.S))
        {
            forwardSpeed = baseSpeed;
        }
        //Prints the current time spent in game each second. 
        //It does this by checking if the time spent in game is equal to the value of the timer variable
        //If it is then it prints the value of timer and adds 1 to it. So that it is executed again in the next second
      
        if (Time.fixedTime == timer)
        {
            print("Timer: " + timer);
            timer = timer + 1;
        }
    }
   
}
