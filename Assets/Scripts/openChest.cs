using UnityEngine;
using System.Collections;

public class openChest : MonoBehaviour 
{
	private Animation _anim;
	private objectHoverHighlight _hoverhighlight;
	private ParticleSystem _particles;
	private bool _open = false;
	private chestObjectGet _objectget;
	private petMovement petMov;
	private petAnimation petAnim;
	private petLookAt petLook;
	private objectHoverHighlight hoverHighlight;
	
	void Start () 
	{
		_anim = gameObject.GetComponent<Animation>();
		_hoverhighlight = gameObject.GetComponent<objectHoverHighlight>();
//		_particles = gameObject.GetComponentInChildren<ParticleSystem>();
//		_objectget = gameObject.GetComponentInChildren<chestObjectGet>();
		petMov = GameObject.Find("pet").GetComponent<petMovement>();
		petLook = GameObject.Find("pet").GetComponent<petLookAt>();
		petAnim = GameObject.Find("pet").GetComponent<petAnimation>();
	}
	
	void Update () 
	{
		
	}
	
	void OnMouseDown ()
	{
		if(!_open)
		{
			Debug.Log (petMov);
			petMov.SetTarget(GameObject.Find("walkLocation").transform);
			petLook.SetTarget(transform);
			petLook.SetWeight(0f);
			petAnim.SetWalking();
			_hoverhighlight.Kill();
		}
		
	}
	
	public void Reveal ()
	{
		_anim.Play("anim_active_chest_open");
//		_particles.Play();
		_open = true;
//		_objectget.Reveal();
		
//		GameObject ball = GameObject.FindGameObjectWithTag("ball");
//		ball.GetComponent<emissivePulse>().enabled = true;
//		fairyLook.SetTarget(ball.transform);
//		fairyLook.SetWeight(1f);
	}
}
