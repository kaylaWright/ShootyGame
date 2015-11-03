using UnityEngine;
using System.Collections;

public class CoroutineHandler : MonoBehaviour 
{
	public delegate IEnumerator CoroutineMethod();
	
	IEnumerator RunCoroutine(CoroutineMethod _method)
	{
		return _method();
	}
	
	public Coroutine StartCoroutineDelegate(CoroutineMethod _method)
	{
		return StartCoroutine("RunCoroutine", _method);
	}
}
