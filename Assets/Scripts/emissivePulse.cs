using UnityEngine;
using System.Collections;

public class emissivePulse : MonoBehaviour 
{
	private Component[] _renderers;
	private Color pulseColor;
	private float pulseValue;
	
	public bool on = true;
	public float endValue = 0.2f;
	public Color startColor = new Color (0f, 0f, 0f, 1f);
	
	void Start () 
	{
		_renderers = gameObject.GetComponentsInChildren<Renderer>();
	}
	
	void Update () 
	{
		if(on)
		{
			pulseValue = Mathf.PingPong(Time.time / 4, endValue);
			pulseColor = new Color (pulseValue, pulseValue, pulseValue, 1);
			
			foreach(Renderer rend in _renderers)
				rend.material.SetColor("_Emission", pulseColor);	
		}
	}
	
	public void Kill()
	{
		on = false;
		pulseColor = Color.black;
		Destroy(this);
	}
}