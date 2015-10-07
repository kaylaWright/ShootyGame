using UnityEngine;
using System.Collections;

public class TreeRotator : MonoBehaviour {

	int spin=0;
	// Use this for initialization
	void Start () {
		spin=Random.Range(-720,720);
		transform.rotation =Quaternion.Euler(270,spin,0);	

	}
	
	// Update is called once per frame
	void Update () {

	}
}
