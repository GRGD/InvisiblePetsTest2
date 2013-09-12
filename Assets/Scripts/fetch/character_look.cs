using UnityEngine;
using System.Collections;

public class character_look : MonoBehaviour 
{
	public Transform mainCamera;
	public Transform ball;
	public float lookSpeed;
	
	private Quaternion _lookRotation;
	private Vector3 _direction;
	private ballThrower _ballThrower;
	private Transform _target;
	
	void Start()
	{
		_ballThrower = GameObject.Find("Main Camera").GetComponent<ballThrower>();
	}
	
	void Update()
	{
		if(_ballThrower.characterHasBall)
			_target = mainCamera;
		else
			_target = ball;
		
		_direction = (_target.position - transform.position).normalized;
		_lookRotation = Quaternion.LookRotation(_direction);
		transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * lookSpeed);
	}
	
	
	/*
	public Transform ball;
	private ballThrower _ballThrower;
	public Transform _camera;
	
	void Start () 
	{
		_ballThrower = GameObject.Find("Main Camera").GetComponent<ballThrower>();
	}
	
	void Update () 
	{
		if(_ballThrower.characterHasBall)
			transform.LookAt(new Vector3(_camera.position.x, _camera.position.y, _camera.position.z));
		else
			transform.LookAt(new Vector3(ball.position.x, ball.position.y, ball.position.z));
	}
	*/
}
