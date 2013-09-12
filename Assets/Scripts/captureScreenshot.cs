using UnityEngine;
using System.Collections;

public class captureScreenshot : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetButtonDown("Screenshot"))
		{
			Capture();
		}
		
		if(Input.GetKeyDown(KeyCode.F11))
		{
			if(Time.timeScale == 0)
				Time.timeScale = 1;
			else
				Time.timeScale = 0;
		}
	}
	
	void Capture()
	{
		Application.CaptureScreenshot("fairyScreenshot.png", 4);
	}
}
