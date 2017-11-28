using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if (gameObject.tag == "Fireball"){
			transform.Translate (0f, 6f * Time.deltaTime, 0f);			
		} else if (gameObject.tag == "Rocket"){
			transform.Translate (6f * Time.deltaTime, 0f, 0f);			
		}
	}
}
