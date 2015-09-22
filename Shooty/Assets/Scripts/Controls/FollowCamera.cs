using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour 
{
	public GameObject target;
	public float damping = 1;

	public float stretchMultiplier = 2.0f;
	private float currentDistance = 0.0f;

	private Vector3 offset;
	
	private Vector3 controllerOffset = Vector3.zero;
	public float controllerEffect = 500.0f;
		
	public void Start() 
	{
		offset = transform.position - target.transform.position;
	}

	public void Update()
	{
		controllerOffset = new Vector3(-Input.GetAxisRaw("Joystick X"), 0, Input.GetAxisRaw("Joystick Y")) * controllerEffect;
	}
	
	public void LateUpdate() 
	{
		//following the player.
		Vector3 desiredPosition = new Vector3(target.transform.position.x, 0, target.transform.position.z) + offset;
		Vector3 position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * damping);
		transform.position = position;

		Vector2 mousePosition = new Vector2(Input.mousePosition.x - Screen.width / 2, Input.mousePosition.y - Screen.height / 2) * stretchMultiplier;
		Vector3 tempPosition = new Vector3(transform.position.x + mousePosition.x, transform.position.y, transform.position.z + mousePosition.y) + controllerOffset;
		
		Vector3 adjustedPosition = Vector3.Lerp(transform.position, tempPosition,  Time.deltaTime);
		transform.position = adjustedPosition;
	}

}