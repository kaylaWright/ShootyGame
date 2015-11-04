using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent (typeof(CharacterController))]
public class Flock : MonoBehaviour
{
	private List<FlockingNPC> flock;
	//prefab so the flock is formed of one type of FlockingNPC.
	//** multiple flock prefabs? 
	public GameObject flockType; 

	//physicality; members of the flock will need to align more or less to this when moving 
	//while still taking into account the visibility of other flock members.
	Vector3 goalRotation = Vector3.zero;
	float heading = 0.0f;

	//desires
	public float averageHungerDesire = 0.0f;
	public float migrationPoint = 0.0f;

	public float averageReproductiveDesire = 0.0f;
	public float reproductionPoint = 0.0f;

	//flock stats
	public int minimumFlockSize = 0;
	public Vector2 initialFlockSizeVariance = Vector2.zero;
	public Vector2 maximumFlockSizeVariance = Vector2.zero;
	private int maximumFlockSize = 0;

	public Vector2 flockSplitVariances = Vector2.zero;
	public float radius = 0.0f;

	public float updateInterval = 0.0f;

	public void Create(FlockingNPC _type)
	{
		if(flock == null)
		{
			flock = new List<FlockingNPC>();
		}

		CreateInitialFlock((int)Random.Range(initialFlockSizeVariance.x, initialFlockSizeVariance.y));
	}
	
	public void Create(List<FlockingNPC> _startingFlock)
	{
		flock = _startingFlock;
		//****
		flockType = _startingFlock[0].transform.parent.gameObject;
	}

	private void CreateInitialFlock(int _startingSize)
	{
		for(int i = 0; i < _startingSize; i++)
		{
			float flockRadius = Mathf.Sqrt(Random.value * radius);
			float angle = Random.value * Mathf.PI * 2;
			float xPos = this.transform.position.x + (flockRadius * Mathf.Cos (angle));
			float zPos = this.transform.position.z + (flockRadius * Mathf.Sin (angle)); 

			GameObject tempMember = Instantiate(flockType) as GameObject;
			tempMember.transform.position = new Vector3(xPos, this.transform.position.y, zPos);
			tempMember.GetComponent<FlockingNPC>().parentFlock = this;
			Debug.Log ("Now.");
			flock.Add(tempMember.GetComponent<FlockingNPC>());

		}
	}
	
	private void Awake()
	{
		if(flock == null)
		{
			flock = new List<FlockingNPC>();
		}
		
		CreateInitialFlock((int)Random.Range(initialFlockSizeVariance.x, initialFlockSizeVariance.y));

		//should continue to do this as needed; will inform flock about overalldesires. 
		StartCoroutine("UpdateAverages");
	}
	
	public void Update()
	{
	}


	private void Reproduce()
	{
		//reduce energies for all members of the flock by an amount relative to the number of members in the flock.

		//create new member of the flock.
		//add it to the list. 
	}

	//when the flock is getting too big, divide into two flocks. 
	private void SplitFlock()
	{
		float flockSplitRatio = Random.Range(flockSplitVariances.x, flockSplitVariances.y);
		int newFlockSize = (int)(flock.Count * flockSplitRatio);

		List<FlockingNPC> newFlock = new List<FlockingNPC>();

		for(int i = 0; i < newFlockSize; i++)
		{
			int index = Random.Range(0, flock.Count);
			newFlock.Add(flock[index]);
			flock.RemoveAt(index);
		}

		//GameObject newFlockObject = Instantiate(flockPrefab) as GameObject;
		//newFlockObject.GetComponent<Flock>().Create(newFlock);
	}
	
	IEnumerator UpdateAverages()
	{
		while(true)
		{
			if(flock.Count > 0)
			{
				UpdateAveragesRoutine();
			}

			yield return new WaitForSeconds(updateInterval);
		}
	}

	private void UpdateAveragesRoutine()
	{
		float hunger = 0.0f;
		float reproduction = 0.0f;

		//Debug.Log ();

		for(int i = 0; i < flock.Count; i++)
		{
			hunger += flock[i].hungerDesire;
			reproduction += flock[i].reproductiveDesire;
		}

		averageHungerDesire = hunger / flock.Count;
		averageReproductiveDesire = reproduction / flock.Count; 
	}
}
