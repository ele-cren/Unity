using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public float moveSpeed = 15f;
	public float padding = 0.5f;
	public float health = 100;

	public AudioClip shot;

	public float projectileSpeed, firingRate = 0.2f;

	public GameObject projectile;

	private float xMin;
	private float xMax;

	// Use this for initialization
	void Start () {

		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftmost = Camera.main.ViewportToWorldPoint (new Vector3(0, 0, distance));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint (new Vector3(1, 0, distance));
		xMin = leftmost.x + padding;
		xMax = rightmost.x - padding;
	}
	
	// Update is called once per frame
	void Update () {
		MovePlayer();
		LaserPlayer();
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

	void Die ()
	{
		Destroy (gameObject);
		SceneManager.LoadScene("Lose", LoadSceneMode.Additive);
		MusicPlayer.isDead = true;
	}

	void MovePlayer ()
	{
		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.position += Vector3.left * moveSpeed * Time.deltaTime;
		} else if (Input.GetKey (KeyCode.RightArrow)) {
			transform.position += Vector3.right * moveSpeed * Time.deltaTime;
		}

		// restrict the player to the game Space
		float newX = Mathf.Clamp(transform.position.x, xMin, xMax);
		transform.position = new Vector3(newX, transform.position.y, transform.position.z);
	}

	void Fire ()
	{
		AudioSource.PlayClipAtPoint(shot, transform.position);
		GameObject laser = Instantiate (projectile, transform.position, Quaternion.identity) as GameObject;
		Rigidbody2D myRb;
		myRb = laser.GetComponent<Rigidbody2D>();
		myRb.velocity = new Vector3 (0, projectileSpeed, 0);
	}

	void LaserPlayer ()
	{
		if (Input.GetKeyDown (KeyCode.Space)) {
			InvokeRepeating ("Fire", 0.000001f, firingRate);
		}
		if (Input.GetKeyUp (KeyCode.Space)) {
			CancelInvoke("Fire");
		}
	}
}
