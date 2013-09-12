using UnityEngine;
using System.Collections;

public class objectHoverHighlight : MonoBehaviour 
{
	private Component[] _renderers;
	
	public bool on = true;
	public Color startColor = new Color (0f, 0f, 0f, 1f);
	public Color highlightColor = new Color (0.2f, 0.2f, 0.2f, 1f);
	
	void Start () 
	{
		_renderers = gameObject.GetComponentsInChildren<Renderer>();
		
		foreach(Renderer rend in _renderers)
			rend.material.SetColor("_Emission", startColor);
	}
	
	void Update () 
	{
		
	}
	
	void OnMouseOver()
	{
		if(on)
		{
			foreach(Renderer rend in _renderers)
				rend.material.SetColor("_Emission", highlightColor);
		}
	}	
	
	void OnMouseExit()
	{
		if(on)
		{
			foreach(Renderer rend in _renderers)
				rend.material.SetColor("_Emission", startColor);
		}
	}
	
	public void Kill()
	{
		on = false;
		foreach(Renderer rend in _renderers)
			rend.material.SetColor("_Emission", startColor);
		
		Destroy(this);
	}
}
