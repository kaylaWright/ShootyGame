using UnityEngine;
using System.Collections;

[RequireComponent (typeof(CharacterController))]

public class PlayerAttack : MonoBehaviour 
{
	//how fast the player's body turns to match the mouse speed.
	public  float turnSpeed = 1.0f;

	//movement vector keeps track of information that the character controller will use to move the player/enemies.
	private Vector3 moveDirection = Vector3.zero;

	private Vector3 virtualCursor = Vector3.zero;
	private Vector3 controllerOffset = Vector3.zero;
	public float controllerEffect = 500.0f;

	public void Update()
	{
		controllerOffset = new Vector3(-Input.GetAxisRaw("Joystick X"), 0, Input.GetAxisRaw("Joystick Y")) * controllerEffect;
	}

	public void LateUpdate () 
	{
		Plane temp = new Plane(Vector3.up, transform.position);
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Quaternion targetRotation = Quaternion.identity;
		float hitDistance = 0.0f;

		if(temp.Raycast(ray, out hitDistance))
		{
			virtualCursor = ray.GetPoint(hitDistance) + controllerOffset;
			targetRotation = Quaternion.LookRotation(virtualCursor - transform.position);
		}

		//movement routine
		//if the playeri s on the ground, take input for movement. Stops changing direction in case of jumped. 
		// ** DO WE WANT A JUMP? Perhaps not, perhaps. Leaving it in for now. Can be easily removed. 
		transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed);

		//attack routines
		if(Input.GetMouseButton(0) || Input.GetButton("Fire"))
		{
			BroadcastMessage("StartShooting");

		}
	}
}
