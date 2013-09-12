using UnityEngine;
using System.Collections;

public class fadeTransitionGUI : MonoBehaviour 
{
	public delegate void finishTransition();
	public static event finishTransition OnFinishTransition;
	
	public Texture fadeTexture;
	public float fadeSpeed;
	
	private float time;
	private string _fadeDirection;
	private float _alpha = 0f;
	private bool moving = false;
	
	void Start () 
	{
		SetFade("out");
	}
	
	void Update () 
	{
		time += Time.deltaTime;
		Fade();
	}
	
	void OnGUI()
	{
		GUI.depth = 10;
		GUI.color = new Color (1f, 1f, 1f, _alpha);
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeTexture);
	}
	
	void Fade()
	{
		if(_fadeDirection == "out")
		{
			_alpha = Mathf.Lerp(1f, 0f, time * fadeSpeed);
		}
		else if(_fadeDirection == "in")
		{
			_alpha = Mathf.Lerp(0f, 1f, time * fadeSpeed);
		}
		
		if(_alpha == 1)
			OnFinishTransition();
	}
	
	public void SetFade(string direction)
	{
		_fadeDirection = direction;
		time = 0f;
	}
}
