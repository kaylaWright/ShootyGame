using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour 
{
	private float tanAngle = 0.0f;

	public GameObject target;
	public float damping = 1;

	public float stretchMultiplier = 2.0f;
	private Vector3 offset;
	
	private Vector3 controllerOffset = Vector3.zero;
	public float controllerEffect = 500.0f;

	private Rect screenRect; 
	private Vector3 lastPosition = Vector3.zero;	

	public float scrollMultiplier; 

	public float minYDistance = 0.0f;
	public float maxYDistance = 0.0f;

	public void Start() 
	{
		offset = transform.position - target.transform.position;
		screenRect = new Rect(0.0f, 0.0f, Screen.width, Screen.height);
		tanAngle = Mathf.Tan(transform.eulerAngles.x * 3.1459f / 180.0f);
	}

	public void Update()
	{
		controllerOffset = new Vector3(-Input.GetAxisRaw("Joystick X"), 0, Input.GetAxisRaw("Joystick Y")) * controllerEffect;

		float scroll = Sign(Input.GetAxis("Mouse ScrollWheel")) * scrollMultiplier;

		if(scroll != 0.0f)
		{
			CalculateScrolledOffset(scroll);
		}
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

	private float Sign(float _num)
	{
		return (_num < 0.0f)? -1.0f: (_num > 0.0f)? 1.0f: 0.0f;
	}

	//take in the scroll and direction.
	private void CalculateScrolledOffset(float _scroll)
	{
		if(_scroll < 0 && offset.y + (_scroll * tanAngle) > maxYDistance)
		{
			offset.y = maxYDistance;
			offset.z = -(tanAngle * maxYDistance) + _scroll;

			return;
		}

		if(_scroll > 0 && offset.y - (_scroll * tanAngle) < minYDistance)
		{
			offset.y = minYDistance;
			offset.z =  -(tanAngle * minYDistance) + _scroll;

			return;
		}

		offset.y -= _scroll * tanAngle;
		offset.z += _scroll ;
	}
}