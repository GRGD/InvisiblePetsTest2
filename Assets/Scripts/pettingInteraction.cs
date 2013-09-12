using UnityEngine;
using System.Collections;

public class pettingInteraction : MonoBehaviour 
{
	private Animator animator; 
	
	[HideInInspector]
	public bool beingPetted;
	
	void Start () 
	{
		animator = GameObject.Find("pet").GetComponent<Animator>();
	} 
	
	void Update () 
	{
		
	}
}
