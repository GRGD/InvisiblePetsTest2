using UnityEngine;
using System.Collections;

public class ARStart_GUI : MonoBehaviour 
{
//	string sceneName; 
	void Start () 
	{
//		sceneName = Application.loadedLevelName;
	}
	
	void Update () 
	{
	
	}
	
	void OnGUI()
	{
		GUI.depth = 11;
		if(Application.loadedLevelName == "arg_test")
		{
			if(GUI.Button(new Rect(0, Screen.height - (Screen.height /6), Screen.width / 6, Screen.height / 6), "Leave AR"))
			{
				Application.LoadLevel("main_gdc_01");
			}
		}
		else
		{
			if(GUI.Button(new Rect(0, Screen.height - (Screen.height /6), Screen.width / 6, Screen.height / 6), "Load AR"))
			{
				Application.LoadLevel("arg_test");	
			}
		}
	}
	
}