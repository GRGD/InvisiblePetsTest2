using UnityEngine;
using System.Collections;

public class ballGet : MonoBehaviour 
{
	private fadeTransitionGUI _fadeTrans;
	private bool loaded = false;
	
	void Start () 
	{
		//Event Listening
		fadeTransitionGUI.OnFinishTransition += OnFinishTransition;
//		_fadeTrans = GameObject.Find("Main Camera").GetComponent<fadeTransitionGUI>();
		_fadeTrans = Camera.main.GetComponent<fadeTransitionGUI>();
	}
	
	void Update () 
	{
	
	}
	
	void OnMouseDown()
	{
		_fadeTrans.SetFade("in");
	}
	
	void OnFinishTransition()
	{
		if(!loaded)
		{
			loaded = true;
			Application.LoadLevel("main_gdc_01");	
		};	
	}
}
