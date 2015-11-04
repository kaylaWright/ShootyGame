using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(CharacterController))]
public class NPC : MonoBehaviour 
{

	//internal/motive forces
	public float health = 0.0f;

	private float energyStores = 0.0f;
	private float persistentEnergyDrain = 0.0f;
	public float hungerDesire = 0.0f;

	public float reproductiveDesire = 0.0f;
	public float minEnergyToReproduce = 0.0f;

	//vision/pathing/movement
	public CharacterController contr;

	public float viewRadius = 0.0f; 
	public float movementSpeed = 0.0f;

	//behaviour
	protected StateMachine stateMachine = null;

	//wander behaviour
	public float wanderDirectionInterval = 0.0f;
	public float maxHeadingChange = 0.0f;
	public float heading = 0.0f;
	public Vector3 goalRotation = Vector3.zero;

	//for attacking/defending
	public GameObject target = null;
	public float attackRadius = 0.0f;

	public List<Attack> weaponList; 
	public int minWeapons = 0;
	public int maxWeapons = 0;

	//$$$$
	public float lootDropPercentge = 0.0f;

	protected void Awake() 
	{
		//controller
		contr = gameObject.GetComponent<CharacterController>();

		//state
		stateMachine = new StateMachine(this);
		stateMachine.SwitchState(new IdleState());

		//initial movement.
		heading = Random.Range(0, 360);
		transform.eulerAngles = new Vector3(0, heading, 0);

		//attack-related
		weaponList = new List<Attack>();
		GenerateWeapons();
	}

	protected virtual void GenerateWeapons()
	{	}

	protected void Update () 
	{
		stateMachine.Update();
	}

	public virtual void Attack()
	{	}

	//may be overriden
	public virtual void Dodge()
	{	}

	//should be overriden 
	protected virtual State CheckState()
	{
		return new WanderState();
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

	public bool CheckTargetVisibility()
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

	public bool GetTargetWithinAttackRange()
	{
		if(target != null)
		{
			return (Vector3.Distance(target.transform.position, gameObject.transform.position) <= attackRadius);
		}

		return false;
	}
}
