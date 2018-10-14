using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipMovement : MonoBehaviour
{
    //The ships left turn speed
    float leftRotationSpeed;
    //The player assigned ship rotation
    public float startRotation = 150;
    //The ships right turn speed
    float rightRotationSpeed;
    //How much slower left rotation is than the right rotation
    [Range(0.1f, 1f)]
    public float leftSlowerRatio = 0.5f;
    //Player assigned ship speed
    public float startSpeed = 5;
    //The current ship speed
    float baseSpeed;
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
    //Player assigned accelerate for the increase of rotationSpeed and baseSpeed
    [Range(0.00000001f, 1f)]
    public float speedIncrease = 0.1f;
    //A variable which let's us use variables from the cameraScript
    public cameraZoom cameraScript;
    //Variable for making sure the warp range increases proportionally to the zoom increase
    float warpIncrease;
    // Use this for initialization
    void Start()
    {
        //If randomSpeed is true the base ship speed gets randomized
        //The base ship speed gets randomized at the start of the game      
        if (randomSpeed == true)
        {
            startSpeed = Random.Range(1, 11);
        }
        //If randomStartPos is true the ship gets a random position within the camera
        if (randomStartPos == true)
        {
            shipLocation.position = new Vector3(Random.Range(-8f, 8f), Random.Range(-4.4f, 4.4f));
        }
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
        //Sets the ship's current speed to the player assigned ship speed
        baseSpeed = startSpeed;
        //Sets both rotations speeds to the player assigned rotation speed
        rightRotationSpeed = startRotation;
        leftRotationSpeed = startRotation;
        //Sets the left rotation to be slower based on the leftSlowerRatio
        leftRotationSpeed = rightRotationSpeed * leftSlowerRatio;
    }


    // Update is called once per frame
    void Update()
    {
        //Makes the ship go forward all the time based on the given speed, in real time
        transform.Translate(baseSpeed * Time.deltaTime, 0f, 0f, Space.Self);
        //Makes it so when you hold "D" the ship rotates to the right independant of framerate
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0f, 0f, -rightRotationSpeed * Time.deltaTime);
        }
        //Makes it so when you hold "A" the ship rotates to the left independant of framerate
        //The rotation is based on the leftSlowerRatio
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0f, 0f, leftRotationSpeed * Time.deltaTime);
        }
        //Makes it so when you hold "S" the ship speed halfs
        if (Input.GetKeyDown(KeyCode.S))
        {
            baseSpeed = baseSpeed / 2;

        }
        //When the "S" key is up the current ship speed is set to the player assigned speed
        if (Input.GetKeyUp(KeyCode.S))
        {
            baseSpeed = baseSpeed * 2;
        }

        //Prints the current time spent in game each second. 
        //It does this by checking if the time spent in game is equal to the value of the timer variable
        //If it is then it prints the value of timer and adds 1 to it. So that it is executed again in the next second
        if (Time.fixedTime == timer)
        {
            print("Timer: " + timer);
            timer = timer + 1;
        }
        //Makes the warpIncrease into the zoom variable from the cameraZoom script
        warpIncrease = cameraScript.zoom;
        //If the x of the rocket is outside the camera it is teleported to the opposite side of the camera
        //It does this by taking the base cords and multiplying it with the zoom variable
        if (transform.position.x < -2.1 * warpIncrease || transform.position.x > 2.1 * warpIncrease)
        {
            shipLocation.position = new Vector3(shipLocation.position.x * -1f, shipLocation.position.y);
        }
        //If the y of the rocket is outside the camera it is teleported to the opposite side of the camera
        //It does this by taking the base cords and multiplying it with the zoom variable
        if (transform.position.y > 1.3 * warpIncrease || transform.position.y < -1.3 * warpIncrease)
        {
            shipLocation.position = new Vector3(shipLocation.position.x, shipLocation.position.y * -1f);
        }
        //Increases baseSpeed based on the seconds passed in game and speedIncrease
        baseSpeed = baseSpeed + (startSpeed * speedIncrease) * Time.deltaTime;
        //Increases both rotation speed based on the seconds passed in game and speedIncrease
        rightRotationSpeed = rightRotationSpeed + (startRotation * speedIncrease) * Time.deltaTime;
        leftRotationSpeed = leftRotationSpeed + (startRotation * speedIncrease) * Time.deltaTime;
    }

}
