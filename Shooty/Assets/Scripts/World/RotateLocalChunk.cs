using UnityEngine;
using System.Collections;

public class RotateLocalChunk : MonoBehaviour {

	private Transform myTransform;
	public bool randomizeRotation = true;
	public Vector3 rotationAxis;
	public float rotationSpeed = 90f;
	
	public float minRotationSpeed = 45f;
	public float maxRotationSpeed = 360f;
	
	// Use this for initialization
	void Start () {
		myTransform = this.transform;
		
		if (randomizeRotation) {
			rotationSpeed = Random.Range(minRotationSpeed, maxRotationSpeed);
			rotationAxis.x = Random.Range(-1f, 1f);
			rotationAxis.y = Random.Range(-1f, 1f);
			rotationAxis.z = Random.Range(-1f, 1f);
		}
	}
	
	// Update is called once per frame
	void Update () {
		myTransform.RotateAround( myTransform.position,  myTransform.TransformDirection(rotationAxis),  rotationSpeed * Time.deltaTime);
	}
	
} // end of class