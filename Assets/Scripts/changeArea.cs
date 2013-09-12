using UnityEngine;
using System.Collections;

public class changeArea : MonoBehaviour 
{
	public Transform character;
	public Transform newTargetPosition;
	public Camera cam;
	
	private fadeTransitionGUI _trans;
	private bool _moving = false;
	private bool _clicked = false;
	
	void Start () 
	{
		//Event Listening
		fadeTransitionGUI.OnFinishTransition += OnFinishTransition;
		
		_trans = GameObject.Find("Main Camera").GetComponent<fadeTransitionGUI>();	
	}
	
	void Update () 
	{
		
	}
	
	void OnMouseDown()
	{
		if(!_clicked)
		{
			_trans.SetFade("in");
			_moving = true;
			_clicked = true;
		}
		
	}
	
	void OnFinishTransition()
	{
		if(_moving)
		{
			_trans.SetFade("out");
			Debug.Log ("OnFinishTransition Called");
			character.position = newTargetPosition.position;
			cam.GetComponent<CameraOrbit>().initiatePos();
			_moving = false;
		}
	}
}
