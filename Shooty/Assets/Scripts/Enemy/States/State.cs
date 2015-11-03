using UnityEngine;
using System.Collections;

public abstract class State
{
	public abstract void BeginState(StateMachine _machine, NPC _owner);
	public abstract void UpdateState(StateMachine _machine);
	public abstract void EndState(StateMachine _machine);
}
