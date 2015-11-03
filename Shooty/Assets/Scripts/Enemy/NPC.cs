using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class NPC : MonoBehaviour 
{

	//internal/motive forces
	public float health = 0.0f;
	private float hunger = 0.0f;
	public float hungerTick = 0.0f;

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
	//the attack range of the highest-distance weapon the NPC has.
	public float attackRadius = 0.0f;

	//$$$$
	public float lootDropPercentge = 0.0f;

	protected void Awake () 
	{
		contr = gameObject.GetComponent<CharacterController>();

		stateMachine = new StateMachine(this);
		stateMachine.SwitchState(new IdleState());

		heading = Random.Range(0, 360);
		transform.eulerAngles = new Vector3(0, heading, 0);
	}

	protected void Update () 
	{
		stateMachine.Update();

		CheckState();
	}

	//should be overriden 
	protected virtual State CheckState()
	{
		return new WanderState();
	}
	
	public void Chase()
	{
		Debug.Log ("Chasing!");
	}

	public void Flee()
	{
		Debug.Log ("Eek! Fleeing!");
	}

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

	public void SetHeading(float _new)
	{
		heading = _new;
		goalRotation = new Vector3(0, heading, 0);
	}
}
