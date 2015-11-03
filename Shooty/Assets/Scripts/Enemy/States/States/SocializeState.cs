using UnityEngine;
using System.Collections;

public class SocializeState : State
{
	NPC owner = null;
	
	public override void BeginState(StateMachine _machine, NPC _owner)
	{
		owner = _owner;
		
		//_machine.coroutineHandler.StartCoroutineDelegate(NewHeading);
	}
	
	public override void UpdateState(StateMachine _machine)
	{
		
	}
	
	public override void EndState(StateMachine _machine)
	{
		_machine.coroutineHandler.StopAllCoroutines();
	}
}
