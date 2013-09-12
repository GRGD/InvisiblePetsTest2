using UnityEngine;
using System.Collections;

public class hudVisibilityManager : MonoBehaviour 
{
	private GameObject _hudHealth;
	private bool _hudHide = false;
	private bool _hudReveal = false;
	private Vector3 _hudHealthRevealedPos;
	private Vector3 _hudHealthHiddenPos;
	private Vector3 _hudHealthCurrentPos;
	public Vector3 _hudHealthVectorTransfrom;
	private Vector3 _hudHealthOrigLocalPos;
	private Vector3 _hudHealthNewLocalPos;
	private float _time;
	private bool _visible = true;
	
	void Start () 
	{
		_hudHealth = GameObject.Find("hud_health");
		_hudHealthOrigLocalPos = _hudHealth.transform.localPosition;
		
		StartCoroutine(AutoHide());
	}
	
	void Update () 
	{
		_hudHealthNewLocalPos = _hudHealthOrigLocalPos + _hudHealthVectorTransfrom;
		_hudHealth.transform.localPosition = _hudHealthNewLocalPos;
		
		/*
		if(Input.GetButtonDown("Fire1"))
			_hudHide = true;
		
		if(Input.GetButtonDown("Fire2"))
			_hudReveal = true;
		*/
		
		if(_hudHide)
		{
			_time += Time.deltaTime;
			float _speed = 3f;
			float _y;
			
			_y = Mathf.Lerp(0, -2, _time * _speed);
			_hudHealthVectorTransfrom = new Vector3(0, _y, 0);
			
			if(_y == -2)
			{
				_time = 0f;
				_hudHide = false;
				_visible = false;
			}
		}
		
		if(_hudReveal)
		{
			_time += Time.deltaTime;
			float _speed = 3f;
			float _y;
			
			_y = Mathf.Lerp(-2, 0, _time * _speed);
			_hudHealthVectorTransfrom = new Vector3(0, _y, 0);
			
			if(_y == 0)
			{
				_time = 0f;
				_hudReveal = false;
				_visible = false;
				StartCoroutine(AutoHide());
			}
		}
	}
	
	IEnumerator AutoHide()
	{
		yield return new WaitForSeconds(3f);
		_hudHide = true;
	}
	
	public void SetVisibility(bool makevisible)
	{
		if(makevisible)
			_hudReveal = true;
		else
			_hudHide = true;
	}
	
	public bool IsVisible()
	{
		if(_visible)
			return true;
		else
			return false;
	}
}
