using UnityEngine;
using System.Collections;

[RequireComponent(typeof(StateMachine))]
[RequireComponent(typeof(CharacterController))]

public class WanderState : State
{
	StateMachine machine = null;
	NPC owner = null;

	public override void BeginState(StateMachine _machine, NPC _owner)
	{
		owner = _owner;
		machine = _machine;

		_machine.coroutineHandler.StartCoroutineDelegate(NewHeading);
	}

	public override void UpdateState(StateMachine _machine)
	{
		owner.transform.eulerAngles = Vector3.Slerp(owner.transform.eulerAngles, owner.goalRotation, Time.deltaTime * owner.wanderDirectionInterval);
		Vector3 forward = owner.transform.TransformDirection(Vector3.forward);
		owner.contr.SimpleMove(forward * owner.movementSpeed);
	}

	public override void EndState(StateMachine _machine)
	{
		_machine.coroutineHandler.StopAllCoroutines();
	}
	
	IEnumerator NewHeading ()
	{
		while (true) 
		{
			NewHeadingRoutine();
			yield return new WaitForSeconds(owner.wanderDirectionInterval);
		}
	}
	
	public void NewHeadingRoutine ()
	{
		var floor = Mathf.Clamp(owner.heading - owner.maxHeadingChange, 0, 360);
		var ceil  = Mathf.Clamp(owner.heading + owner.maxHeadingChange, 0, 360);
		owner.SetHeading(Random.Range(floor, ceil));
	}
}
