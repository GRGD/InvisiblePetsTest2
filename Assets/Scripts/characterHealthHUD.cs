using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class characterHealthHUD : MonoBehaviour 
{
	public int currentHearts;
	public int maxHearts;
	public GameObject heart;
	public float distanceFromCamera;
	
	private Camera _camera;
	private List<GameObject> _heartArray = new List<GameObject>();
	private float _heartspacing = 2f;
	private float _xpos = 0f;
	private bool _inithealth = true;
	private bool _allowHeartAdd;
	private petAnimation fairyAnim;
	
	void Start () 
	{
		//_camera = GameObject.Find("Main Camera").GetComponent<Camera>();
		_camera = Camera.main.GetComponent<Camera>();
		gameObject.transform.position = _camera.ViewportToWorldPoint(new Vector3(.93f, .1f, distanceFromCamera));
		fairyAnim = GameObject.Find("pet").GetComponent<petAnimation>();
		
		InitHealth();
	}
	
	void Update () 
	{
		fairyAnim.SetHearts(currentHearts);
	}
	
	public void InitHealth()
	{
		for(int i = 1; i <= currentHearts; i++)
		{
			StartCoroutine("CreateHeart");
			
			if(i < currentHearts)
				_xpos += _heartspacing;
		}
		_inithealth = false;
	}
	
	IEnumerator CreateHeart ()
	{
		GameObject spawnedHeart;
		
		//spawn at hud_health transform
		spawnedHeart = Instantiate(heart, gameObject.transform.position, _camera.transform.rotation) as GameObject;
		
		//parent to hud_health
		spawnedHeart.transform.parent = gameObject.transform;
		_heartArray.Add(spawnedHeart);
		
		//move to correct position
		spawnedHeart.transform.Translate(new Vector3(-_xpos, 0f, 0f),Space.Self);
		
		//play animation if adding or subtracting hearts
		if(!_inithealth)
		{
			//play scale up animation
			spawnedHeart.GetComponentInChildren<Animation>().Play("anim_heartUI_scale_up");
			
			//wait for animation to be over
			float animLength = spawnedHeart.GetComponentInChildren<Animation>().animation["anim_heartUI_scale_up"].length;
			yield return new WaitForSeconds(animLength);
		}
		
		spawnedHeart.GetComponentInChildren<Animation>().Play("anim_heartUI_idle");
		
		yield break;
	}
	
	IEnumerator RemoveHeart ()
	{
		GameObject lastHeart;
		lastHeart = _heartArray[_heartArray.Count - 1];
		
		lastHeart.GetComponentInChildren<Animation>().Play("anim_heartUI_scale_down");
		
		float animLength = lastHeart.GetComponentInChildren<Animation>().animation["anim_heartUI_scale_down"].length;
		
		yield return new WaitForSeconds(animLength);
		Destroy(lastHeart);
		_heartArray.RemoveAt(_heartArray.Count - 1);
		
		yield break;	
	}
	
	public void UpdateHealth(int amt)
	{
		//subtract health
		if(currentHearts > currentHearts + amt)
		{
			currentHearts += amt;
			_xpos -= _heartspacing;
			StartCoroutine("RemoveHeart");
		}
		
		//add health (if not at max health)
		if(currentHearts < currentHearts + amt && currentHearts != maxHearts)
		{
			currentHearts += amt;
			_xpos += _heartspacing;
			StartCoroutine("CreateHeart");
		}
		
	}
}
