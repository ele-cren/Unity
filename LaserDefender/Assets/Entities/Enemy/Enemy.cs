using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public int health = 100;

	public GameObject projectile;

	public float projectileSpeed;

	public float shotsPerSeconds = 0.5f;

	public int scoreValue = 150;

	public AudioClip shot, death;

	private ScoreKeeper score;

	void Start ()
	{
		score = GameObject.Find("Score").GetComponent<ScoreKeeper>();
	}

	void OnTriggerEnter2D (Collider2D trigger)
	{
		Projectile laser = trigger.gameObject.GetComponent<Projectile> ();
		if (laser) {
			laser.Hit();
			health -= laser.GetDamages();
			if (health <= 0) {
				Die();
			}
		}
	}

	void Die(){
		AudioSource.PlayClipAtPoint(death, transform.position);
		score.ScorePoints(scoreValue);
		Destroy (gameObject);
	}

	void Fire ()
	{
		AudioSource.PlayClipAtPoint(shot, transform.position);
		GameObject laser = Instantiate(projectile, transform.position, Quaternion.identity);
		Rigidbody2D myRb = laser.GetComponent<Rigidbody2D>();
		myRb.velocity = new Vector3 (0, -projectileSpeed, 0);
	}

	void Update ()
	{
		float probability = Time.deltaTime * shotsPerSeconds;
		if (Random.value < probability) {
			Fire();
		}
	}
}
