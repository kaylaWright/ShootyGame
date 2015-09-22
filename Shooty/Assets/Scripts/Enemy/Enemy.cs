using UnityEngine;
using System.Collections;

[RequireComponent (typeof(CharacterController))]

public class Enemy : MonoBehaviour 
{
	public GameObject target;
	
	public float targetViewDistance = 10.0f;
	public float targetAttackDistance = 5.0f;

	void Start () 
	{
	
	}


	void Update () 
	{
		if(CheckTargetDistance(targetViewDistance))
		{
			FaceTarget();
		}

		if(CheckTargetDistance(targetAttackDistance))
		{
			BroadcastMessage("StartShooting");
		}
		else
		{
			MoveTowardsTarget();
		}
	}

	#region Movement Behaviours
	
	//ensure that the target is visible from where it is. 
	public bool CheckTargetDistance(float _dist)
	{
		if(target != null)
		{
			//calculate the distance between the AI character and the player character.
			ushort distanceFromTarget; 
			distanceFromTarget = (ushort)Vector3.Distance(transform.position, target.transform.position);
			
			//if the AI character outside of the viewing distance of the AI, it cannot see the player.
			if(distanceFromTarget > _dist)
			{
				return false;
			}
			
			//otherwise, the target is within the viewing distance of the AI, so we return true. 
			return true;
			
		}
		
		return false;
	}

	//turn to face your target. 
	public void FaceTarget()
	{
		//the rotation to determin how the AI needs to rotate to look at it's target. 
		Quaternion lookAtRotation;
		//rotate the AI to face the target (lookrotation = rotation to look at). 
		lookAtRotation = Quaternion.LookRotation(target.transform.position - transform.position);
		
		//Spherical Linear Interpolation (SLERP), which is a fancy way of saying rotate the 
		//AI over time to face the player. Currently set to a time of 0.5s, or 500ms.
		transform.rotation = Quaternion.Slerp(transform.rotation, lookAtRotation, Time.deltaTime/0.5f);
	}

	private void FindNearestTarget()
	{
	}

	
	//move towards the target. 
	public void MoveTowardsTarget()
	{
	}
	
	//idling AI behaviour
	public void Wander()	
	{
		
	}
	
	public void SlowDown()
	{

	}
	
	#endregion

}
