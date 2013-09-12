using UnityEngine;
using System.Collections;

public class transitionGUI : MonoBehaviour 
{
	public delegate void finishTransition();
	public static event finishTransition OnFinishTransition;
	
	public Texture transitionTex;
	public float transitionSpeed;
	public Rect _transitionPos;
	
	private float time;
	private float _swipeOutStartX;
	private float _swipeInStartX;
	private string _swipeDirection;
	
	void Start () 
	{
		_transitionPos = new Rect(0, 0, Screen.width * 1.5f, Screen.height);
		
		_swipeOutStartX = _transitionPos.x;
		_swipeInStartX = _transitionPos.x - _transitionPos.width;
		_swipeDirection = "out";
	}
	
	void Update () 
	{
		time += Time.deltaTime;
		Swipe();
	}
	
	void OnGUI()
	{
		GUI.depth = 10;
		GUI.DrawTexture(_transitionPos, transitionTex);
	}
	
	void Swipe()
	{
		if(_swipeDirection == "out")
		{
			_transitionPos.x = Mathf.Lerp(_swipeOutStartX, -(_transitionPos.width), time * transitionSpeed);
		}
		else if(_swipeDirection == "in")
		{
			_transitionPos.x = Mathf.Lerp(_swipeInStartX, -1, time * transitionSpeed);
		}
		
		if(_transitionPos.x == -1)
			OnFinishTransition();
	}
	
	public void SetSwipe(string direction)
	{
		_swipeDirection = direction;
		time = 0f;
	}
}

