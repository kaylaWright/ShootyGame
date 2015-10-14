using UnityEngine;
using System.Collections;

public class Demon : NPC 
{
	void Awake() 
	{
		health = 0.0f;
		
		//vision/pathing.
		viewRadius = 0.0f;
		movementSpeed = 0.0f;
		
		//$$$$
		lootDropPercentge = 0.0f;
	}

	void Update () 
	{
		//check the distance to the target/player; if it's outside of the viewing radius, wander. 
		if(CheckTargetVisibility())
		{
			Chase();
		}
		else
		{
			Wander();
		}
	}
}
