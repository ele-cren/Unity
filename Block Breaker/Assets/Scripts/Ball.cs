using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	private Paddle paddle;

	public static bool gameStarted = false;

	public static Vector3 paddleToBallVector;

	private Rigidbody2D rb;

	public static int nbBalls = 1;

	public static bool first = true;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		paddle = FindObjectOfType<Paddle>();
		if (first == true){
			paddleToBallVector = this.transform.position - paddle.transform.position;
			first = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (!gameStarted){
			this.transform.position = paddle.transform.position + paddleToBallVector;
			if (Input.GetMouseButtonDown(0)){
				gameStarted = true;
				rb.velocity = new Vector2(0f, 10f);
			}
		}
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.contacts.Length > 0){
			ContactPoint2D contact = coll.contacts[0];
			if (coll.gameObject.name == "Paddle" && contact.normal == Vector2.up){
				rb.velocity = new Vector2((contact.point.x - paddle.transform.position.x) * 4f, 10f);
			}
		}
	}
}
