using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour 
{
	protected float attackRate = 1.0f;
	protected bool canAttack = true;



	public virtual void BeginAttack() 
	{
	}
}
