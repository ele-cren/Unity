using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

	public GameObject gun;
	public GameObject projectile;
	private GameObject parentProjectile;
	private Transform lane;
	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		GetLane();

		parentProjectile = GameObject.Find("Projectiles");
		if (!parentProjectile){
			parentProjectile = new GameObject("Projectiles");
		}
	}

	void Update(){
		if (IsAttackerAhead() && animator.GetBool("isIdle") == false){
			animator.SetBool("isAttacking", true);
		} else {
			animator.SetBool("isAttacking", false);
		}
	}

	private void Fire(){
		GameObject proj = Instantiate(projectile, gun.transform.position, Quaternion.identity);
		proj.transform.parent = parentProjectile.transform; 
	}

	bool IsAttackerAhead(){
		if (lane.transform.childCount <= 0){
			return false;
		}

		foreach (Transform attacker in lane.transform){
			if (attacker.transform.position.x <= 10 && attacker.transform.position.x > transform.position.x){
				return true;
			}
		}
		return false;
	}

	void GetLane(){
		GameObject spawners = GameObject.Find("Spawner");

		foreach (Transform thisLane in spawners.transform){
			if (thisLane.position.y == transform.position.y){
				lane = thisLane;
				return ;
			}
		}
		Debug.LogWarning("Please create spawners.");
	} 
}
