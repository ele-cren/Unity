using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Attacker))]
public class Fox : MonoBehaviour {

	private Animator anim;
	private Attacker attacker;

	// Use this for initialization
	void Start () {
		attacker = GetComponent<Attacker>();
		anim = GetComponent<Animator>();
	}

	void OnTriggerEnter2D (Collider2D trigger){
		GameObject obj = trigger.gameObject;
		if (obj){
			if (obj.GetComponent<Defender>()){
				if (obj.GetComponent<Stone>()){
					anim.SetTrigger("Trigger Jump");
				} else {
					anim.SetBool("isAttacking", true);
					attacker.Attack(obj);
				}
			}
		}
	}
}