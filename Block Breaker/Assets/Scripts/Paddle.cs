using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
	
	public static Sprite[] paddleSprites;

	private float myTime;

	private float timeRestrict;

	private int rocketMun;

	private GameObject ball;

	private Ball ballAuto;

	public static float size;

	public bool autoPlay = false;

	void Start(){
		size = 0.75f;
		ballAuto = GameObject.FindObjectOfType<Ball>();
		paddleSprites = Resources.LoadAll<Sprite>("Sprites/Bricks");
	}

	// Update is called once per frame
	void Update ()
	{
		MoveWithMouse ();
		if (myTime >= 5 || (rocketMun == 0 && gameObject.tag == "PaddleRocket")){
			GetComponent<SpriteRenderer>().sprite = paddleSprites[4];
			gameObject.tag = "Paddle";
		}
		if (gameObject.tag == "PaddleLaser"){
			myTime += Time.deltaTime;
			timeRestrict += Time.deltaTime;
			if (Input.GetMouseButtonDown(0) && (timeRestrict / 0.5f) >= 1f){
				timeRestrict = 0;
				Instantiate (Resources.Load("Prefabs/Fireball", typeof(GameObject)), new Vector3(transform.position.x - 0.5f, transform.position.y + 0.4f, 0f), Quaternion.identity);
				Instantiate (Resources.Load("Prefabs/Fireball", typeof(GameObject)), new Vector3(transform.position.x + 0.5f, transform.position.y + 0.4f, 0f), Quaternion.identity);
			}
		}
		if (gameObject.tag == "PaddleRocket"){
			timeRestrict += Time.deltaTime;
			if (Input.GetMouseButtonDown(0) && rocketMun > 0 && (timeRestrict / 0.5f) >= 1f){
				rocketMun--;
				timeRestrict = 0;
				Instantiate (Resources.Load("Prefabs/Rocket", typeof(GameObject)), new Vector3(transform.position.x, transform.position.y + 0.9f, 0f), Quaternion.Euler(0, 0, 90));
			}
		}
	}

	void MoveWithMouse ()
	{
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
		Vector3 paddlePos = new Vector3 (Mathf.Clamp(mousePosInBlocks, size, 16 - size), this.transform.position.y, this.transform.position.z);
		this.transform.position = paddlePos;
	}

	void OnTriggerEnter2D(Collider2D trigger){
		if (trigger.tag == "Life"){
			BonusLife(trigger);
		} else if (trigger.tag == "Laser"){
			BonusLaser(trigger);
		} else if (trigger.tag == "RocketLauncher"){
			BonusRocket(trigger);
		} else if (trigger.tag == "Enlarge"){
			BonusEnlarge(trigger);
		} else if (trigger.tag == "Mult") {
			BonusMult(trigger);
		}
	}

	void BonusLife(Collider2D trigger){
		if (Health.lifePoints == Health.lifeMax){
			Health.lifeMax++;
			Health.lifePoints++;
			System.Array.Resize(ref Health.hearts, Health.hearts.Length + 1);
			Health.hearts[Health.hearts.Length - 1] = Instantiate(Resources.Load("Prefabs/FullHeart", typeof(GameObject)), new Vector3(0.5f + (Health.hearts.Length - 1), 11.5f, 0f), Quaternion.identity) as GameObject;
		} else {
			Health.hearts[Health.lifePoints].GetComponent<SpriteRenderer>().sprite = Health.emptyHeart[1];
			Health.lifePoints++;
		}
		Destroy (trigger.gameObject);
	}

	void BonusLaser(Collider2D trigger){
		myTime = 0;
		timeRestrict = 0.5f;
		GetComponent<SpriteRenderer>().sprite = paddleSprites[2];
		gameObject.tag = "PaddleLaser";
		Destroy (trigger.gameObject);
	}

	void BonusRocket(Collider2D trigger){
		rocketMun = 3;
		timeRestrict = 0.5f;
		GetComponent<SpriteRenderer>().sprite = paddleSprites[3];
		gameObject.tag = "PaddleRocket";
		Destroy (trigger.gameObject);
	}

	void BonusEnlarge(Collider2D trigger){
		size *= 2;
		gameObject.transform.localScale = new Vector3 (transform.localScale.x * 2, transform.localScale.y, transform.localScale.z);
		gameObject.tag = "PaddleEnlarge";
		Destroy (trigger.gameObject);
	}

	void BonusMult(Collider2D trigger){
		Ball.nbBalls += 2;
		ball = GameObject.Find("Ball");
		GameObject b1 = Instantiate(ball, new Vector3(ball.transform.position.x + 0.5f , ball.transform.position.y + 0.7f, 0f), Quaternion.identity) as GameObject;
		GameObject b2 = Instantiate(ball, new Vector3(ball.transform.position.x - 0.5f, ball.transform.position.y + 0.7f, 0f), Quaternion.identity) as GameObject;
		b1.GetComponent<Rigidbody2D>().velocity = new Vector3((b1.transform.position.x - (ball.transform.position.x)) * 8 , (b1.transform.position.y - (ball.transform.position.y + 0.35f)) * 15, 0f);
		b2.GetComponent<Rigidbody2D>().velocity = new Vector3((b2.transform.position.x - (ball.transform.position.x)) * 8, (b2.transform.position.y - (ball.transform.position.y + 0.35f)) * 15, 0f);
		ball.GetComponent<Rigidbody2D>().velocity = new Vector3((ball.transform.position.x - (ball.transform.position.x)) * 8, (ball.transform.position.y - (ball.transform.position.y + 0.35f)) * 20, 0f);
	}
}