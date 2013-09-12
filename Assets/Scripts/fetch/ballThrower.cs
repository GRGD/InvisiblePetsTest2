using UnityEngine;
using System.Collections;

public class ballThrower : MonoBehaviour {
	
	public Ray ray;
	public GameObject ball;
	public float throwingForce;
	public float throwingPower;
	public float maxThrowingPower;
	public GameObject ballTrigger;
	public bool playerHasBall;
	public bool characterHasBall;
	
	private bool _mobile;
	private petLookAt fairyLook;
	private GameObject fairy;
	private Vector3 fairyStartPos;
	
	void Start () 
	{
		//Check for platfrom
		if(Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
			_mobile = false;
		else
			_mobile = true;
		
		fairyLook = GameObject.Find("pet").GetComponent<petLookAt>();
		fairy = GameObject.Find("pet");
		
		throwingPower = 1f;
		playerHasBall = true;
		characterHasBall = false;
		fairyStartPos = fairy.transform.position;
	}
	
	void Update () 
	{
		if(playerHasBall)
		{
			//Input for _mobile and pc
			if(_mobile)
			{
				foreach (Touch touch in Input.touches)
				{
					
					if(throwingPower < maxThrowingPower)
						throwingPower += Time.deltaTime;
					
					if(touch.phase == TouchPhase.Ended)
					{
						ray = camera.ScreenPointToRay(new Vector3(touch.position.x, touch.position.y, 0));
						throwBall();
					}
				}
			}
			else
			{
				if(Input.GetButton("Fire1"))
				{
					if(throwingPower < maxThrowingPower)
						throwingPower += Time.deltaTime;
				}
				
				if(Input.GetButtonUp("Fire1"))
				{
					ray = camera.ScreenPointToRay(Input.mousePosition);
					throwBall();
				}
			}
		}
		
		//Ball Trigger control
		if(playerHasBall)
		{
			ballTrigger.SetActive(false); //turn off ballTrigger if player has ball
		}
		else
		{
			StartCoroutine(turnTriggerOn(1f)); //turn ballTrigger back on after time
		}
		
		//Fairy Ball Chasing Control
		if(!playerHasBall && !characterHasBall)
		{
			//chase ball	
		}
		else if(characterHasBall)
		{
			//give ball to player	
		}
		else if(playerHasBall)
		{
			//go back to default pos	
		}
	}
	
	void throwBall()
	{
		playerHasBall = false;
		characterHasBall = false;
		fairyLook.SetTarget(ball.transform);
		fairyLook.SetWeight(1f);
		ball.rigidbody.isKinematic = false;
		ball.rigidbody.WakeUp();
		ball.rigidbody.AddForce(ray.direction * (throwingForce * throwingPower));
		throwingPower = 1f;
	}
	
	IEnumerator turnTriggerOn(float wait)
	{
		yield return new WaitForSeconds(wait);
		ballTrigger.SetActive(true);
	}
}
