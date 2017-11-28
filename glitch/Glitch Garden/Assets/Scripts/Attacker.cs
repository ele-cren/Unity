using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {

	private Animator anim;
	private GameObject currentTarget;
	private float currentSpeed;
	public int spawnProb = 50;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector2.left * currentSpeed * Time.deltaTime);
		if (!currentTarget){
			anim.SetBool("isAttacking", false);
		}
	}

	public void StrikeCurrentTarget(int damage){
		if (currentTarget){
			Health health = currentTarget.GetComponent<Health>();
			health.DealingDamage(damage);
		}
	}

	public void SetSpeed(float speed){
		currentSpeed = speed;
	}

	public void Attack(GameObject target){
		currentTarget = target;
	}
}
