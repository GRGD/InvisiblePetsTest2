using UnityEngine;
using System.Collections;

public class CameraOrbit : MonoBehaviour 
{
    public Transform target;
    public float distance = 15f;
    public float xSpeed = 250.0f;
    public float ySpeed = 120.0f;
	public float xMinLimit = 0;
	public float xMaxLimit = 0;
    public float yMinLimit = -20;
    public float yMaxLimit = 80;
	public float distanceMin = 3;
	public float distanceMax = 15;
	public float zoomSpeed = 8;
	public bool mobile;

    private float x = 0.0f;
    private float y = 0.0f;
	private bool isMouseOneDown = false;
	private bool moveing;
	private Vector3 zoomLine =  Vector3.zero;
	private bool _zoomed = false;
	private float _oldDist;
	private float _newDist;

    void Start () 
	{
		if(Application.platform == RuntimePlatform.WindowsPlayer|| Application.platform == RuntimePlatform.WindowsEditor)
		{
			mobile = false;
		}
		else
		{
			mobile = true;
			xSpeed/=10;
			ySpeed/=10;
		}
        var angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;

        // Make the rigid body not change rotation
        if (rigidbody) 
            rigidbody.freezeRotation = true;
		
		initiatePos();
	}

	void Click()
	{
		
	}

    void Update () 
	{
		//Mobile and Mouse Input
		if(mobile)
		{
			foreach (Touch touch in Input.touches)
			{
				if(Input.touchCount == 1)
				{
					if(TouchPhase.Began == touch.phase)
					{
						Click();
					}
						if(TouchPhase.Moved== touch.phase)
						{
							OrientCamera(touch.deltaPosition.x, touch.deltaPosition.y);
						}
				}
			}
		}
		else
		{
			if (target && Input.GetButton("Fire1"))
		  	{
		 		OrientCamera(Input.GetAxis("Mouse X"),Input.GetAxis("Mouse Y"));
			}
		
			if (target)
		  	{
				float scrollamt = Input.GetAxis("Mouse ScrollWheel");
		 		distance += -(scrollamt) * zoomSpeed;
				distance = Mathf.Clamp(distance, distanceMin, distanceMax);
			}
		
		}
		
		//Camera Smooth Zooming
		transform.position = (Quaternion.Euler(y, x, 0)) * new Vector3(0.0f, 0.0f, -distance) + target.position;
		
	}

	void OrientCamera(float xMove, float yMove)
	{
		x += xMove * xSpeed * Time.deltaTime;
		y -= yMove * ySpeed * Time.deltaTime;
		y = ClampAngle(y, yMinLimit, yMaxLimit);
		x = ClampAngle(x, xMinLimit, xMaxLimit);		
					
	    transform.rotation = Quaternion.Euler(y, x, 0);
	    transform.position = (Quaternion.Euler(y, x, 0)) * new Vector3(0.0f, 0.0f, -distance) + target.position;			
	}

	public void OnZoomedIn ()
	{
		_zoomed = true;
		//transform.rotation = Quaternion.Euler(y, x, 0);
		//transform.position = (Quaternion.Euler(y, x, 0)) * new Vector3(0.0f, 0.0f, -distance) + target.position;
	}		

	public void OnZoomedOut ()
	{
		_zoomed = false;
		//transform.rotation = Quaternion.Euler(y, x, 0);
		//transform.position = (Quaternion.Euler(y, x, 0)) * new Vector3(0.0f, 0.0f, -distance) + target.position;
	}


	public void initiatePos()
	{
		x += Input.GetAxis("Mouse X") * xSpeed * Time.deltaTime;
        y -= Input.GetAxis("Mouse Y") * ySpeed * Time.deltaTime;

        y = ClampAngle(y, yMinLimit, yMaxLimit);
		x = ClampAngle(x, xMinLimit, xMaxLimit);
	
		//distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel")*5, distanceMin, distanceMax);

        transform.rotation = Quaternion.Euler(y, x, 0);
        transform.position = (Quaternion.Euler(y, x, 0)) * new Vector3(0.0f, 0.0f, -distance) + target.position;
	}

    static float ClampAngle(float angle, float min, float max) 
    {
        if (angle < -360)
        {
            angle += 360;
        }
        if (angle > 360)
        {
            angle -= 360;
        }
        return Mathf.Clamp(angle, min, max);
    }
}