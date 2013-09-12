using UnityEngine;
using System.Collections;

public class fairyKick : MonoBehaviour 
{
	private petAnimation fairyAnim;
	private openChest ochest;
	
	void Start () 
	{
	 	fairyAnim = GameObject.Find("pet").GetComponent<petAnimation>();
		ochest = GameObject.Find("active_chest").GetComponent<openChest>();
	}
	
	void Update () 
	{
	
	}
	
	IEnumerator OnTriggerEnter(Collider c)
	{
		if(c.gameObject.name == "fairyNew")
		{
			fairyAnim.SetKick();
			
			yield return new WaitForSeconds(1.5f);
			ochest.Reveal();
		}
	}
}
