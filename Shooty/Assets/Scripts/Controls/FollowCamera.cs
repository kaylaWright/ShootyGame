using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour 
{
	public GameObject target;
	public Vector3 maxOffset;
	public float damping = 1;

	public float stretchMultiplier = 2.0f;
	private float currentDistance = 0.0f;

	private Vector3 offset;
	
	private Vector3 controllerOffset = Vector3.zero;
	public float controllerEffect = 500.0f;

	private Rect screenRect; 
	private Vector3 lastPosition = Vector3.zero;	

	public float scrollMultiplier; 

	public void Start() 
	{
		offset = transform.position - target.transform.position;
		screenRect = new Rect(0.0f, 0.0f, Screen.width, Screen.height);
	}

	public void Update()
	{
		controllerOffset = new Vector3(-Input.GetAxisRaw("Joystick X"), 0, Input.GetAxisRaw("Joystick Y")) * controllerEffect;

		offset.y -= (Input.GetAxis("Mouse ScrollWheel") * scrollMultiplier);
	}
	
	public void LateUpdate() 
	{
		//following the player.
		Vector3 desiredPosition = new Vector3(target.transform.position.x, 0, target.transform.position.z) + offset;
		Vector3 position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * damping);
		transform.position = position;

		Vector3 tempPosition = Vector3.zero;
		if(screenRect.Contains(Input.mousePosition))
		{
			Vector2 mousePosition = new Vector2(Input.mousePosition.x - Screen.width / 2, Input.mousePosition.y - Screen.height / 2) * stretchMultiplier;
			Vector3 temp = new Vector3(transform.position.x + mousePosition.x, transform.position.y, transform.position.z + mousePosition.y) + controllerOffset;
			tempPosition = temp;
			lastPosition = temp;
		}
		else
		{
			tempPosition = lastPosition;
		}

		Vector3 adjustedPosition = Vector3.Lerp(transform.position, tempPosition,  Time.deltaTime);
		transform.position = adjustedPosition;
	}

}