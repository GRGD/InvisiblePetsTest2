using UnityEngine;
using System.Collections;

public class playfetch_GUI : MonoBehaviour 
{
	private ballThrower _ballThrower;
	
	void Start () 
	{
		_ballThrower = gameObject.GetComponent<ballThrower>();
	}
	
	void Update () 
	{
		
	}
	
	void OnGUI()
	{
		GUI.depth = 20;
		
		GUI.VerticalSlider(new Rect(Screen.width * 0.01f, Screen.height * 0.25f, Screen.width, Screen.height * 0.5f), _ballThrower.throwingPower, 1, _ballThrower.maxThrowingPower);
		
		GUI.Label(new Rect(Screen.width * 0.01f, Screen.height * 0.1f, Screen.width * 0.5f, Screen.height), 
			"Left click to throw the ball in that direction! " +
			"\nHold down the click to charge the power of the throw." +
			"\nWatch your charge meter below.");
	}
}
