using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public bool inPlay = false;

	private Rigidbody myRb;
	private Vector3 initialPos;

	// Use this for initialization
	void Start () {
		initialPos = transform.position;
		myRb = GetComponent<Rigidbody>();
		myRb.useGravity = false;
	}
	
	public void Launch(Vector3 speed){
		myRb.useGravity = true;
		myRb.velocity = speed;
		inPlay = true;
	}

	public void Reset(){
		transform.position = initialPos;
		myRb.velocity = Vector3.zero;
		myRb.useGravity = false;
		inPlay = false;
		myRb.constraints = RigidbodyConstraints.FreezeAll;
		myRb.constraints = RigidbodyConstraints.None;		
		transform.rotation = Quaternion.identity;
	}
}
