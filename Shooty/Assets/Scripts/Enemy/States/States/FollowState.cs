using UnityEngine;
using System.Collections;

public class FollowState : State
{
	NPC owner = null;
	
	public override void BeginState(StateMachine _machine, NPC _owner)
	{
		owner = _owner;
		_machine.coroutineHandler.StartCoroutineDelegate(NewHeading);
	}
	
	public override void UpdateState(StateMachine _machine)
	{

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
			Vector3 direction = owner.transform.position - owner.target.transform.position;
			Quaternion awayRotation = Quaternion.LookRotation(direction);
			owner.goalRotation = new Vector3(0.0f, awayRotation.eulerAngles.y, 0.0f);
		}
	}
}
