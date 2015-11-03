using UnityEngine;
using System.Collections;

public class ChaseState : State
{
	NPC owner = null;
	
	public override void BeginState(StateMachine _machine, NPC _owner)
	{
		owner = _owner;
		
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
		if(owner.target != null)
		{
			Vector3 direction = owner.target.transform.position - owner.transform.position;
			Quaternion awayRotation = Quaternion.LookRotation(direction);
			owner.goalRotation = new Vector3(0.0f, awayRotation.eulerAngles.y, 0.0f);
		}
	}
}