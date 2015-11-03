using UnityEngine;
using System.Collections;

public class AttackState : State 
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
			//if(//enemy is able to attack)
			//AttackRoutine();
			//
			//else if//random chance for a dodge attack?
			//MovementRoutine();
			//yield return new WaitForSeconds(owner attack recharge);
			//}
		}
	}
	
	public void AttackRoutine ()
	{
		if(owner.target != null)
		{
			owner.Attack();

		}
	}

	public void MovementRoutine()
	{
		if(owner.target != null)
		{
			//circle target? 
			//some kind of repositioning within attack radius? 

			//dash attack? 

			//chance of a dodge if it's been hit?
			//owner.Dodge();?? 
		}
	}
}
