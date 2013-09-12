using UnityEngine;
using System.Collections;

public class ballManager : MonoBehaviour {
	
	public GameObject character_hands;
	
	private Vector3 positionDefault;
	private ballThrower ballThrower;
	private petAnimation fairyAnim;
	private petLookAt fairyLook;
	private Transform cam;

	
	void Start () 
	{
		positionDefault = transform.position;
			
		ballThrower = GameObject.Find("Main Camera").GetComponent<ballThrower>();
		fairyAnim = GameObject.Find("pet").GetComponent<petAnimation>();
		fairyLook = GameObject.Find("pet").GetComponent<petLookAt>();
		cam = GameObject.Find("Main Camera").transform;
		
	}
	
	void Update () 
	{
		if(ballThrower.characterHasBall)
		{
			transform.position = character_hands.transform.position;
		}
	}
	
	void OnTriggerEnter(Collider c)
	{
		if(c.name == "ball_trigger")
		{
			rigidbody.isKinematic = true;
			rigidbody.Sleep();
			transform.position = positionDefault;
			ballThrower.characterHasBall = false;
			ballThrower.playerHasBall = true;
			fairyLook.SetTarget(cam);
		}		
		
		if(c.name == "petting_belly_location" || c.name == "petting_head_location")
		{
			rigidbody.isKinematic = true;
			rigidbody.Sleep();
			ballThrower.characterHasBall = true;
			ballThrower.playerHasBall = false;
			fairyLook.SetTarget(cam);
		}
	}
}
