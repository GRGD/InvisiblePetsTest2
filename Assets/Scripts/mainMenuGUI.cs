using UnityEngine;
using System.Collections;

public class mainMenuGUI : MonoBehaviour 
{
	private crackEgg eggscript;
	private GameObject logo;
	private Rect invisiblePlayButton = new Rect(0, 0, Screen.width, Screen.height);
	private bool started = false;
	private ARStart_GUI arbutton;
	
	void Start () 
	{
		eggscript = GameObject.Find("egg").GetComponent<crackEgg>();
		logo = GameObject.Find("arpets_logo");
		arbutton = GetComponent<ARStart_GUI>();
		arbutton.enabled = false;
	}
	
	void Update () 
	{
		if(Input.GetButtonDown("Fire1") && invisiblePlayButton.Contains(Input.mousePosition))
		{
			if(!started)
				Begin();
			
			started = true;
		}
	}
	
	void Begin()
	{
		arbutton.enabled = true;
		eggscript.enabled = true;
		logo.SetActive(false);
		gameObject.animation.Play();
	}
}
