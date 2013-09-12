using UnityEngine;
using System.Collections;

public class chestObjectGet : MonoBehaviour 
{
	public GameObject _object;
	public GameObject cam;
	public float speed;
	
	private GameObject _spawnedObject;
	private bool _objectget = false;
	private Transform _objectSpawn;
	private cutsceneMoveCamera _camCutscene;
	private Vector3 _objectSpawnOrigPos;
	private Vector3 _objectspawnNewPos;
	private float _time;
	private Transform cameraLocation;
	private petMovement fairyMov;
	private petLookAt fairyLook;
	
	void Start () 
	{
		_objectSpawn = gameObject.transform.Find("mesh_active_chest_bottom/objectSpawn");
		_camCutscene = cam.GetComponent<cutsceneMoveCamera>();
		cameraLocation = gameObject.transform.Find ("cameraLocation");
		fairyMov = GameObject.Find("pet").GetComponent<petMovement>();
		fairyLook = GameObject.Find("pet").GetComponent<petLookAt>();
		
		//get original position and new position for Vector3 Lerp
		_objectSpawnOrigPos = _objectSpawn.position;
		_objectspawnNewPos = _objectSpawnOrigPos + new Vector3(0, 4, 0);
	}
	
	void Update () 
	{
		
		//If object exists, do the Vector3 Lerp
		if(_spawnedObject != null)
		{
			_time += Time.deltaTime * speed;
			_spawnedObject.transform.position = Vector3.Lerp (_objectSpawnOrigPos, _objectspawnNewPos, _time);
		}
	}
	
	public void Reveal ()
	{
		_objectget = true;
		_spawnedObject = Instantiate(_object, _objectSpawn.position, _objectSpawn.rotation) as GameObject;
		_camCutscene.MoveCameraTo(cameraLocation, _spawnedObject.transform);
	}
}
