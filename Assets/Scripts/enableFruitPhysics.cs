using UnityEngine;
using System.Collections;

public class enableFruitPhysics : MonoBehaviour 
{
	
	private Rigidbody[] _rigids;
	private int _arrayNext;
	private fruitingManager _fruitingManager;
	private characterHealthHUD _health;
	private hudVisibilityManager _hudVisibility;
	private petAnimation fairyAnim;
	private petLookAt fairyLook;
	
	public Transform eatingPosition;
	
	void Start () 
	{
		_rigids = gameObject.GetComponentsInChildren<Rigidbody>();
		 _arrayNext = _rigids.Length - 1;
		_fruitingManager = GameObject.Find("fruitingManager").GetComponent<fruitingManager>();
		_health = GameObject.Find("hud_health").GetComponent<characterHealthHUD>();
		_hudVisibility = GameObject.Find("HUD Camera").GetComponent<hudVisibilityManager>();
		fairyAnim = GameObject.Find("pet").GetComponent<petAnimation>();
		fairyLook = GameObject.Find("pet").GetComponent<petLookAt>();

	}
	
	void Update ()
	{
		
	}
	
	public IEnumerator eatingSequence ()
	{
		if(_arrayNext > -1 && !_fruitingManager.currentlyFruiting)
		{
			//throw fruit into air
			_fruitingManager.currentlyFruiting = true;
			_rigids[_arrayNext].transform.parent = null;
			_rigids[_arrayNext].isKinematic = false;
			_rigids[_arrayNext].AddForce(Vector3.up * 7,ForceMode.Impulse);
			_rigids[_arrayNext].AddTorque(Vector3.left * 7, ForceMode.Impulse);
			
			//suspend fruit in air
			yield return new WaitForSeconds(.5f);
			_rigids[_arrayNext].useGravity = false;
			_rigids[_arrayNext].velocity = Vector3.zero;
			
			//grab particle systems from fruitParticles script on the current fruit array object
			fruitParticles _fruitparticles = _rigids[_arrayNext].GetComponent<fruitParticles>();
			ParticleSystem _halo = _fruitparticles.haloParticle.GetComponent<ParticleSystem>();
			ParticleSystem _crumbs = _fruitparticles.crumbsParticle.GetComponent<ParticleSystem>();
			
			//play halo particle system & unparent so its not affected by the spinning rigidbody
			_halo.Play();
			_halo.gameObject.transform.parent = null;
			
			//teleport out
			yield return new WaitForSeconds(3f);
			_rigids[_arrayNext].gameObject.GetComponentInChildren<Animation>().Play("fruit_teleport_out");
			
			//teleport in front of character
			yield return new WaitForSeconds(1f);
			_rigids[_arrayNext].isKinematic = true;
			_rigids[_arrayNext].gameObject.transform.position = eatingPosition.position;
			_rigids[_arrayNext].gameObject.transform.rotation = eatingPosition.rotation;
			_rigids[_arrayNext].gameObject.transform.parent = eatingPosition;
			_rigids[_arrayNext].gameObject.GetComponentInChildren<Animation>().Play("fruit_teleport_in");
			
			//play crumbs particle & play fruit eat shrinking anim
			yield return new WaitForSeconds(1f);
			_rigids[_arrayNext].gameObject.GetComponentInChildren<Animation>().Play("fruit_eat_shrink");
			_crumbs.Play();
			_crumbs.gameObject.transform.parent = null;
			
			//play character eating animation, destory fruit, set hud visibility, and send health gain message
			fairyAnim.SetEating();
			fairyLook.SetWeight(0f);
			yield return new WaitForSeconds(2f);
			Destroy(_rigids[_arrayNext].gameObject);
			fairyLook.SetWeight(1f);
			
			if(!_hudVisibility.IsVisible())
			{
				_hudVisibility.SetVisibility(true);
				yield return new WaitForSeconds(0.8f);
			}
			
			_health.UpdateHealth(1);
			
			
			//ready for next object in array & fairy look at player again
			_arrayNext -= 1;
			_fruitingManager.currentlyFruiting = false;
		}
	}
}
