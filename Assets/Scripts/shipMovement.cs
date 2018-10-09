using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipMovement : MonoBehaviour
{
    //The ships left turn speed
    float leftRotationSpeed;
    //The ships base turn speed
    public float baseRotationSpeed;
    //How much slower left rotation is than the right rotation
    [Range(0.1f, 1f)]
    public float leftSlowerRatio;
    //Player assigned ship speed
    public float baseSpeed;
    //The current ship speed
    float forwardSpeed;
    //Lets the players decide if they want to have random speed or not
    public bool randomSpeed = true;
    //Lets the player decide if they want a random start position
    public bool randomStartPos = true;
    //Variables for each ship type
    public SpriteRenderer ship1;
    public SpriteRenderer ship2;
    public SpriteRenderer ship3;
    //Variable for getting a random ship number
    int randomShip;
    //The amount of time while in game
    int timer;
    //The current location of the ship sprite
    public Transform shipLocation;

    // Use this for initialization
    void Start()
    {
        
        //If randomSpeed is true the base ship speed gets randomized
        //The base ship speed gets randomized at the start of the game      
        if (randomSpeed == true)
        {
            baseSpeed = Random.Range(1, 11);
        }
        //If randomStartPos is true the ship gets a random position within the camera
        if (randomStartPos == true)
        {
            shipLocation.position = new Vector3(Random.Range(-8f, 8f), Random.Range(-4.4f, 4.4f));
        }
        //Sets the ship's current speed to the player assigned ship speed
        forwardSpeed = baseSpeed;
        //Sets the left rotation to be slower based on the leftSlowerRatio
        leftRotationSpeed = baseRotationSpeed * leftSlowerRatio;
        //Resets the timer so that it counts normally each time you play
        timer = 1;
        //Sets each spriterenderer to false
        ship1.enabled = false;
        ship2.enabled = false;
        ship3.enabled = false;
        //Picks a number bewtween 1 and 3
        //Depending on the number one of the ships gets their spriterenderer enabled
        randomShip = Random.Range(1, 4);
        if (randomShip == 1)
        {
            ship1.enabled = true;
        }
        if (randomShip == 2)
        {
            ship2.enabled = true;
        }
        if (randomShip == 3)
        {
            ship3.enabled = true;
        }

    }


    // Update is called once per frame
    void Update()
    {
        //Makes the ship go forward all the time based on the given speed, in real time
        transform.Translate(forwardSpeed * Time.deltaTime, 0f, 0f, Space.Self);
        //Makes it so when you hold "W" the ship speed doubles
        if (Input.GetKey(KeyCode.W))
        {
            forwardSpeed = baseSpeed * 2;
        }
        //When you release W the speed resets
        if (Input.GetKeyUp(KeyCode.W))
        {
            forwardSpeed = baseSpeed;
        }
        //Makes it so when you hold "D" the ship rotates to the right independant of framerate
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0f, 0f, -baseRotationSpeed * Time.deltaTime);
        }
        //Makes it so when you hold "A" the ship rotates to the left independant of framerate
        //The rotation is based on the leftSlowerRatio
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0f, 0f, leftRotationSpeed * Time.deltaTime);
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



        //If the x of the rocket is below or above +- 10.5 it is teleported to the oppiosite side
        if (transform.position.x < -10.5 || transform.position.x > 10.5)
        {
            shipLocation.position = new Vector3(shipLocation.position.x * -1f, shipLocation.position.y);
        }
        //If the y of the rocket is below or above +- 10.5 it is teleported to the oppiosite side
        if (transform.position.y > 6.5 || transform.position.y < -6.5)
        {
            shipLocation.position = new Vector3(shipLocation.position.x, shipLocation.position.y * -1f);
        }

    }

}
