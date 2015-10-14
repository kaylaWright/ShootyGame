using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class NPC : MonoBehaviour 
{

	//internal
	public float health = 0.0f;

	//vision/pathing/movement
	private CharacterController contr;

	public float viewRadius = 0.0f; 
	public float movementSpeed = 0.0f;

	//wander behaviour
	public float wanderDirectionChangeTiming = 0.0f;
	public float maxHeadingChange = 0.0f;
	private	float heading = 0.0f;
	private Vector3 goalRotation = Vector3.zero;

	//for attacking/defending
	public GameObject target = null;
	//the attack range of the highest-distance weapon the NPC has.
	public float attackRadius = 0.0f;

	//$$$$
	public float lootDropPercentge = 0.0f;

	void Awake () 
	{
		contr = gameObject.GetComponent<CharacterController>();
	}

	void Update () 
	{
	
	}

	#pragma region Movement

	public virtual void Move()
	{

	}

	#pragma region Wander 
	public void Wander()
	{
		Debug.Log ("Wandering!");
	}

	#pragma endregion

	public void Chase()
	{
		Debug.Log ("Chasing!");
	}

	public void Flee()
	{
		Debug.Log ("Eek! Fleeing!");
	}

	#pragma endregion

	#pragma region Hobbes

	public virtual void Attack()
	{
		Debug.Log ("RAWR! ATTACKING.");
	}

	public void TakeDamage(float _damage)
	{
		health -= _damage;

		if(health <= 0.0f)
		{
			Die();
		}
	}

	public void Die()
	{
		//spawn loot if needed.

		//destroy this.
		if(gameObject)
		{
			Destroy (gameObject);
		}
	}

	#pragma endregion

	#pragma internal

	protected bool CheckTargetVisibility()
	{
		if(target != null)
		{
			if(Vector3.Distance(target.transform.position, gameObject.transform.position) <= viewRadius)
			{
				return true;
			}
		}

		return false;
	}

	#pragma endregion 
}
