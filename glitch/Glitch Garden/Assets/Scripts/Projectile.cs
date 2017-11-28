using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	public int damages = 20;
	public float speed = 2;

	// Update is called once per frame
	void Update () {
		transform.Translate (Vector2.right * speed * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D collider){
		GameObject obj = collider.gameObject;
		Health health = obj.GetComponent<Health>();

		if (obj.GetComponent<Attacker>()){
			health.DealingDamage(damages);
			Destroy (gameObject);
		}
	}
}
