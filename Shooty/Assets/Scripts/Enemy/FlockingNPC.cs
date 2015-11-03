using UnityEngine;
using System.Collections;
using System.Collections.Generic; 

[RequireComponent(typeof(CharacterController))]
public class FlockingNPC : NPC 
{
	List<FlockingNPC> flock; 
	FlockingNPC flockLeader = null; 

	public float reproductiveDesire = 0.0f;
	public float reproductionPoint = 0.0f;
	public float maximumFlockSize = 0.0f;

	
	new void Awake () 
	{
		base.Awake();
	}

	new void Update () 
	{
		//check hunger need.

		//check reproductive need.

		//wander. 
	}
}
