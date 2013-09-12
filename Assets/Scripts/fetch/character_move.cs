using UnityEngine;
using System.Collections;

public class character_move : MonoBehaviour {
	
	public GameObject ball;
	public float characterSpeed;
	public GameObject mainCamera;
	
	private Vector3 _defaultPos;
	private Vector3 _currentPos;
	private ballThrower _ballThrower;
	
	void Start () 
	{
		_ballThrower = GameObject.Find("Main Camera").GetComponent<ballThrower>();
		_defaultPos = transform.position;
	}
	
	void Update () 
	{
		//set current position
		_currentPos = transform.position;
		
		//move character
		if(!_ballThrower.playerHasBall)
			transform.position = Vector3.MoveTowards(_currentPos, new Vector3(ball.transform.position.x, 0, ball.transform.position.z), Time.deltaTime * characterSpeed);
		else
			transform.position = Vector3.MoveTowards(_currentPos, _defaultPos, Time.deltaTime * characterSpeed);
		
		if(_ballThrower.characterHasBall)
			transform.position = Vector3.MoveTowards(_currentPos, new Vector3(mainCamera.transform.position.x, 0, mainCamera.transform.position.z), Time.deltaTime * characterSpeed);

	}
}
