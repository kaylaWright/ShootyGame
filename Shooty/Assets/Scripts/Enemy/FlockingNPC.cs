using UnityEngine;
using System.Collections;

public class FlockingNPC : NPC 
{
	public Flock parentFlock = null;
	public float maxDistanceFromFlockPoint = 0.0f;

	public float minimumAlignment = 0.0f;
	public float minimumCohesion = 0.0f;
	public float minimumSeparation = 0.0f;
	
}
