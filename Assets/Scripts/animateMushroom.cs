using UnityEngine;
using System.Collections;

public class animateMushroom : MonoBehaviour {
	
	private soundArray sounds;
	private int c;
	private AudioSource soundSource;
	
	public GameObject mushroomMesh;
	public GameObject mushroomParticle;
	
	void Start () 
	{
		sounds = mushroomMesh.GetComponent<soundArray>();
		soundSource = mushroomMesh.GetComponent<AudioSource>();
	}
	
	void Update () 
	{
		
	}
	
	void OnMouseDown()
	{
		if(!mushroomMesh.animation.IsPlaying("anim_wushroomWiggle"))
		{
			mushroomMesh.animation.Play();
			c = Random.Range(0, 3);
			c = Mathf.RoundToInt(c);
			soundSource.clip = sounds.soundClips[c];
			soundSource.Play();
		}
		if(!mushroomParticle.particleSystem.IsAlive())
			mushroomParticle.particleSystem.Play();
	}
	
}
