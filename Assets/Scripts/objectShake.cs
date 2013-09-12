using UnityEngine;
using System.Collections;

public class objectShake : MonoBehaviour 
{
	public AnimationClip shakeAnim;
	
	private Animation _anim;
	private enableFruitPhysics _childPhysics;
	
	void Start () 
	{
		_anim = gameObject.GetComponentInChildren<Animation>();
		_childPhysics = gameObject.GetComponent<enableFruitPhysics>();
	}
	
	void Update () 
	{
		
	}
	
	void OnMouseDown ()
	{
		if(!_anim.isPlaying)
		{
			_anim.clip = shakeAnim;
			_anim.Play();
			StartCoroutine(_childPhysics.eatingSequence());
		}
	}
}
