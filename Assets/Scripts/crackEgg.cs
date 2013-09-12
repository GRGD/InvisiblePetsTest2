using UnityEngine;
using System.Collections;

public class crackEgg : MonoBehaviour 
{
	public Texture[] eggStates;
	public Mesh brokenState;
	public GameObject crackParticle;
	public GameObject hitParticle;
	
	private GameObject _egg;
	private fadeTransitionGUI _fadeTrans;
	private int _taps = 0;
	private bool loaded = false;
	
	void Start () 
	{
		//Event Listening
		fadeTransitionGUI.OnFinishTransition += OnFinishTransition;
		
		_egg = GameObject.Find("mesh_egg");
		_fadeTrans = GameObject.Find("Main Camera").GetComponent<fadeTransitionGUI>();
	}
	
	void Update () 
	{
		Debug.Log("I EXIST SOMEWHERE!");
	}
	
	void OnMouseDown()
	{
		//increase tap count and play egg wobble animation
		if(enabled && !_egg.GetComponent<Animation>().isPlaying)
		{
			_taps += 1;
			_egg.GetComponent<Animation>().Play();
		}
		
		if(_taps == 2)
		{
			_egg.renderer.material.mainTexture = eggStates[1];
			Instantiate(crackParticle, transform.position + new Vector3(0, 4, 0), transform.rotation);
		}
		if(_taps == 4)
		{
			_egg.renderer.material.mainTexture = eggStates[2];
			Instantiate(crackParticle, transform.position + new Vector3(0, 4, 0), transform.rotation);
		}
		if(_taps == 6)
		{
			_egg.GetComponent<MeshFilter>().mesh = brokenState;
			_fadeTrans.SetFade("in");
			Instantiate(crackParticle, transform.position + new Vector3(0, 4, 0), transform.rotation);
		}
		
		if(_taps > _taps - 1)
			Instantiate(hitParticle, transform.position + new Vector3(0, 2, 0), transform.rotation);
	}
	
	void OnFinishTransition()
	{
		if(!loaded)
		{
			loaded = true;
			Application.LoadLevel("main_gdc_02");	
		}
	}
}
