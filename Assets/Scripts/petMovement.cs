using UnityEngine;
using System.Collections;

public class petMovement : MonoBehaviour 
{
	public float speed = 1f;
	
	private CharacterController controller;
	private Transform target;
	private Vector3 moveDirection;
	private Vector3 lookDirection;
	private petAnimation petAnim;
	
	void Start () 
	{
		controller = GameObject.Find("pet").GetComponent<CharacterController>();
		petAnim = GameObject.Find ("pet").GetComponent<petAnimation>();
	}
	
	void Update () 
	{
		
		//setup moveDirection vector
		if(target)
		{
			moveDirection = target.position - transform.position;
			moveDirection = new Vector3(moveDirection.x, 0, moveDirection.z);
			//moveDirection = moveDirection.normalized;
			
			controller.Move(moveDirection.normalized * Time.deltaTime * speed);
			
			//look at location
			lookDirection = new Vector3(moveDirection.x, transform.position.y, moveDirection.z);
			Quaternion rot = Quaternion.LookRotation(lookDirection.normalized, Vector3.up);
			transform.rotation = Quaternion.Slerp(transform.rotation, new Quaternion(0, rot.y, 0, rot.w), Time.deltaTime * 2f);
			
			//stand still if not moving
			if(moveDirection.magnitude < .2f)
			{
				petAnim.SetIdle();
				controller.Move(Vector3.zero);
				target = null;
			}
		}
		
		//Debug.Log(moveDirection.magnitude);
	}
	
	public void SetTarget(Transform t)
	{
		target = t;
	}
}
