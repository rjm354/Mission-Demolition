using UnityEngine;
using System.Collections;

public class FollowCam : MonoBehaviour {
    static public FollowCam S; //a FollowCam Singleton

    //fields set in the Unity Inspector pane
    public float easing = 0.05f;
    public Vector2 minXY;
    public bool _____________________;

    //fields set dynamically
    public GameObject poi; //the point of interest
    public float camZ; //the desired Z pos of the camera

	// Use this for initialization
	void Start ()
    {
	
	}
	
    void Awake()
    {
        S = this;
        camZ = this.transform.position.z;
    }

	// Update is called once per frame
	void FixedUpdate ()
    {
	    //if there's only one line of code following an if, it doesn't need braces
        if(poi == null)
        {
            return; //return if there is no poi
        }
        //get the position of the poi
        Vector3 destination = poi.transform.position;
        //Limit the X & Y to minimum values
        destination.x = Mathf.Max(minXY.x, destination.x);
        destination.y = Mathf.Max(minXY.y, destination.y);
        //Interpolate from the current Camera position toward destination
        destination = Vector3.Lerp(transform.position, destination, easing);
        //retain a destination.z of camZ
        destination.z = camZ;
        //set the camera to the destination
        transform.position = destination;
        //set the orthographicSize of the Camera to keep Ground in view
        this.GetComponent<Camera>().orthographicSize = destination.y + 10;
	}
}
