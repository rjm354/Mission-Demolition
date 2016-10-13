using UnityEngine;
using System.Collections;

public class Slingshot : MonoBehaviour {
    //fields set in the Unity Inspector pane
    public GameObject prefabProjectile;
    public bool __________;
    //fields set dynamically
    public GameObject launchPoint;
    public Vector3 launchPos;
    public GameObject projectile;
    public bool aimingMode;
	void Start ()
    {
       
	}
    void Awake()
    {
        Transform launchPointTrans = transform.FindChild("LaunchPoint");
        launchPoint = launchPointTrans.gameObject;
        launchPoint.SetActive(false);
        launchPos = launchPointTrans.position;
    }
    void OnMouseEnter()
    {
        //print("Slingshot:OnMouseEnter()");
        launchPoint.SetActive(true);
    }
    void OnMouseExit()
    {
        //print("Slingshot:OnMouseExit()");
        launchPoint.SetActive(false);
    }
    void OnMouseDown()
    {
        //The player has pressed the mouse button while over Slingshot
        aimingMode = true;
        //Instantiate a Projectile
        projectile = Instantiate(prefabProjectile) as GameObject;
        //start it at the launchpoint
        projectile.transform.position = launchPos;
        //set it to isKinematic for now
        projectile.GetComponent<Rigidbody>().isKinematic = true;
    }
}
