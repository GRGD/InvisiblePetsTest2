using UnityEngine;
using System.Collections;

public class petAnimation : MonoBehaviour 
{
	private Animator anim;
	private AnimatorStateInfo blayer;
	private AnimatorStateInfo holdlayer;
	
	[HideInInspector]
	public bool beingPetted;
	
	void Start () 
	{
		anim = GameObject.Find("pet").GetComponent<Animator>();
	    blayer = anim.GetCurrentAnimatorStateInfo(0);
	    holdlayer = anim.GetCurrentAnimatorStateInfo(1);
	} 
	
	void Update () 
	{
		
	}
	
	void LateUpdate ()
	{
		//reset animator parameters automatically
		anim.SetBool("touchedHead", false);
		anim.SetBool("touchedBelly", false);
		anim.SetBool("eating", false);
		anim.SetBool("idle", false);
		anim.SetBool("walking", false);
		anim.SetBool("kick", false);
		anim.SetBool("holdball", false);
	}
	
	public void SetPurr ()
	{
		if(blayer.IsName("Base Layer.idleBasic"))
		{
			anim.SetBool("touchedHead", true);
		}
	}
	
	public void SetTickle ()
	{
		if(blayer.IsName("Base Layer.idleBasic"))
			anim.SetBool("touchedBelly", true);	
	}
	
	public void SetEating ()
	{
		anim.SetBool("eating", true);
	}
	
	public void SetWalking ()
	{
		anim.SetBool("walking", true);	
	}
	
	public void SetIdle()
	{
		anim.SetBool("idle", true);	
	}
	
	public void SetHearts(int amt)
	{
		anim.SetInteger("hearts", amt);
	}
	
	public void SetKick()
	{
		anim.SetBool("kick", true);
	}
	
	public  void SetBallHold(bool hold)
	{
		//anim.SetBool("ballhold", true);
		if(hold)
			anim.SetLayerWeight(1, 1f);
		else
			anim.SetLayerWeight(1, 0f);
	}
}
