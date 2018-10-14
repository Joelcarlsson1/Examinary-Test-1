using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraZoom : MonoBehaviour {
    //The zoom at which the camera starts at
    float startZoom = 5;
    //The variable used to change the camera zoom
    //It is public so that we can use it in the shipMovement script
    public float zoom;
    //Player assigned increase for the zoom
    [Range (0.000001f, 0.5f)]
    public float zoomIncrease = 0.1f;
	// Use this for initialization
	void Start ()
    {
        //Resets the zoom to start at a certain value
        zoom = startZoom;
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Increases the zoom based on the startZoom and the player assigned zoomIncrease. Undependant of fps
        zoom = zoom + (startZoom * zoomIncrease) * Time.deltaTime;
        //Changes the zoom of the camera to the current zoom
        Camera.main.orthographicSize = zoom;
    }
}
