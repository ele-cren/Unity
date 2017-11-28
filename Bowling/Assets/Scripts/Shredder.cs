using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour {

	void OnTriggerExit(Collider coll){
		if (coll.gameObject.GetComponentInParent<Pin>()){
			Destroy (coll.gameObject.transform.parent.gameObject);
		}
	}
}
