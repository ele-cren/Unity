using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

	public float standingThreshold = 10f;
	private Rigidbody rb;

	void Start(){
		rb = GetComponent<Rigidbody>();
	}

	public bool isStanding(){
		float tiltX = Mathf.Abs(transform.rotation.eulerAngles.x);
		float tiltZ = Mathf.Abs(transform.rotation.eulerAngles.z);

		if ((tiltX < standingThreshold || tiltX > 360f - standingThreshold) && (tiltZ < standingThreshold || tiltZ > 360f - standingThreshold)){
			return true;
		}
		return false;
	}

	public void Raise(){
		if (isStanding()){
			transform.rotation = Quaternion.identity;
			transform.Translate(new Vector3(0, 40, 0));
			rb.constraints = RigidbodyConstraints.FreezeAll;
			rb.useGravity = false;		
		}

	}

	public void Lower(){
		transform.Translate(new Vector3(0, -40, 0));
		rb.constraints = RigidbodyConstraints.None;
		rb.useGravity = true;
	}
}
