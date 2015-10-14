using UnityEngine;
using System.Collections;

[RequireComponent (typeof(CharacterController))]

public class PlayerMovement : MonoBehaviour 
{
	public  float movementSpeed = 200.0f; 
	public float turnSpeed = 10.0f;

	//character controller handles the brunt of non-physics based movement -> don't reinvent the wheel!
	private CharacterController contr; 

	//movement vector keeps track of information that the character controller will use to move the player/enemies.
	private Vector3 moveDirection = Vector3.zero;
	private Quaternion lookAtRotation = Quaternion.identity;

	private Vector3 floatAmount = Vector3.zero;
	public float baseFloatSpeed = 5.0f;

	private void Start()
	{
		contr = GetComponent<CharacterController>();
	}
	
	private void Update () 
	{
		//controlled movement/rotation.

		moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

		if(moveDirection != Vector3.zero)
		{
			lookAtRotation = Quaternion.LookRotation(moveDirection);
		}

		floatAmount = new Vector3(0.0f, (Mathf.Sin(Time.time) * baseFloatSpeed), 0.0f);
	
		transform.rotation = Quaternion.Lerp(gameObject.transform.rotation, lookAtRotation, turnSpeed * Time.deltaTime);

		contr.Move(moveDirection * movementSpeed * Time.deltaTime);
		contr.Move(floatAmount * Time.deltaTime);

	}
}
