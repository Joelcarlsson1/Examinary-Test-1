using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroid : MonoBehaviour
{
    //A variable which let's us use variables from the cameraScript
    public cameraZoom cameraScript;
    //Variable for making sure the warp range increases proportionally to the zoom increase
    float asteroidWarpIncrease;
    //The current location of the asteroid sprites
    public Transform asteroidLocation;
    //The player assigned baseSpeed for the asteroids
    public float baseAsteroidSpeed = 5;
    //The player assigned rotationSpeed for the asteroids
    public float asteroidRotationSpeed = 60;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Makes the asteroids rotate constantly based on the player assigned rotationSpeed
        transform.Rotate(0, 0, asteroidRotationSpeed * Time.deltaTime);
        //Makes the asteroids go forward all the time based on the given speed, in real time
        transform.Translate(baseAsteroidSpeed * Time.deltaTime, 0f, 0f, Space.World);
        //Makes the warpIncrease into the zoom variable from the cameraZoom script
        asteroidWarpIncrease = cameraScript.zoom;
        //If the x of the asteroid is outside the camera it is teleported a random location on the opposite side of the camera
        //It does this by taking the base cords and multiplying it with the zoom variable and then getting a random y value
        if (transform.position.x < -2.1 * asteroidWarpIncrease || transform.position.x > 2.1 * asteroidWarpIncrease)
        {
            asteroidLocation.position = new Vector3(asteroidLocation.position.x * -1f, (Random.Range(-1f, 1f) *asteroidWarpIncrease));
        }
        //If the y of the asteroid is outside the camera it is teleported to a random location on the opposite side of the camera
        //It does this by taking the base cords and multiplying it with the zoom variable and then getting a random y value
        if (transform.position.y > 1.3 * asteroidWarpIncrease || transform.position.y < -1.3 * asteroidWarpIncrease)
        {
            asteroidLocation.position = new Vector3((Random.Range(-1.8f, 1.8f) *asteroidWarpIncrease), asteroidLocation.position.y * -1f);
        }
    }
}
