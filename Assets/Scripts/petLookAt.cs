using UnityEngine;
using System.Collections;

public class petLookAt : MonoBehaviour 
{
	public float speed = 3f;
	public Transform target;
	public float weight = 1f;
	
	private float time;
	private float newWeight = 1f;
	private Vector3 smoothTarget;
	private Animator animator;
	
	void Start () 
	{
		animator = GetComponent<Animator>();
	}
	
	void Update () 
	{
		time += Time.deltaTime;
		
		//smooth target
		animator.SetLookAtPosition(target.position);
		
		//smooth weighting
		animator.SetLookAtWeight(weight);
		
		if(newWeight == 1f)
		{
			weight = Mathf.Lerp(0f, 1f, time * speed);
		}
		else if(newWeight == 0f)
		{
			weight = Mathf.Lerp(1f, 0f, time * speed);
		}
		
	}
	
	public void SetWeight(float w)
	{
		newWeight = w;
		
		time = 0f;
	}
	
	public void SetTarget(Transform t)
	{
		target = t;
		
		time = 0f;
	}
}