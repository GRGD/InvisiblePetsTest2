using UnityEngine;
using System.Collections;

public class fairyBody : MonoBehaviour 
{
	private petAnimation fairyAnim;
	
	void Start () 
	{
		fairyAnim = GameObject.Find("pet").GetComponent<petAnimation>();
	}
	
	void Update () {
	
	}
	
	void OnMouseDown()
	{
		fairyAnim.SetTickle();
	}
}
