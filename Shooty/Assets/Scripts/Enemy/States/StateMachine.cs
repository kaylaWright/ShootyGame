using UnityEngine;
using System.Collections;

public class StateMachine
{
	public NPC owner = null;

	private State currentState = null;

	private GameObject coroutineHolder = null;
	public CoroutineHandler coroutineHandler = null;

	public StateMachine(NPC _owner)
	{
		owner = _owner;

		coroutineHolder = new GameObject();
		coroutineHolder.AddComponent<CoroutineHandler>();
		coroutineHandler = coroutineHolder.GetComponent<CoroutineHandler>();
		coroutineHolder.transform.parent = owner.transform;
		coroutineHolder.name = "Coroutine Manager";
	}
	
	public void SwitchState(State _new)
	{
		if(currentState != null)
		{
			currentState.EndState(this);
		}

		if(_new != null)
		{
			currentState = _new;
			currentState.BeginState(this, owner);
		}
	}

	public void Update()
	{
		if(currentState != null)
		{
			currentState.UpdateState(this);
		}
	}

	public bool CheckCurrentState(State _new)
	{
		return (_new.GetType() == currentState.GetType());
	}
}
