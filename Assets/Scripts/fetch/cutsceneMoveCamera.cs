using UnityEngine;
using System.Collections;

public class cutsceneMoveCamera : MonoBehaviour 
{
	public float rotationSpeed = 1f;
	public float smoothTime = 2f;
	
	private Transform newLocation;
	private Transform spawnedObject;
	private CameraOrbit camOrbit;
	private Vector3 origLocation;
	private float time;
	private bool inCutscene = false;
	private Vector3 velocity = Vector3.zero;

	void Start () 
	{
		GameObject cam = GameObject.Find ("Main Camera");
		camOrbit = cam.GetComponent<CameraOrbit>();
	}
	
	void Update () 
	{
		if(inCutscene)
		{
			//move position
			gameObject.transform.position = Vector3.SmoothDamp(gameObject.transform.position, newLocation.position, ref velocity, smoothTime);
			
			//look rotation
			time += Time.deltaTime * rotationSpeed;
			Quaternion rot = Quaternion.LookRotation(spawnedObject.position - transform.position);
			transform.rotation = Quaternion.Slerp(transform.rotation, rot, time);
		}
	}
	
	public void MoveCameraTo(Transform location, Transform chestObject)
	{
		camOrbit.enabled = false;
		origLocation = gameObject.transform.position;
		spawnedObject = chestObject;
		newLocation = location;
		inCutscene = true;
	}
	
	public void MoveCameraBack()
	{
		inCutscene = false;
	}
}
