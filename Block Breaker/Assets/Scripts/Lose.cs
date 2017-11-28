using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lose : MonoBehaviour {

	public static int lifePoints = 3;

	private LevelManager levelManager;

	private GameObject bonus;

	private GameObject paddle;

	private Health health;

	void Start(){
		bonus = GameObject.Find("Bonus");
		paddle = GameObject.Find("Paddle");
		levelManager = FindObjectOfType<LevelManager>();
		health = FindObjectOfType<Health>();
	}

	void OnTriggerEnter2D(Collider2D trigger){
		if (trigger.tag == "Ball" && Ball.nbBalls == 1){
			for (int i = 0; i <= bonus.transform.childCount - 1; i++){
				Destroy (bonus.transform.GetChild(i).gameObject);
			}
			ResetPaddle();
			health.DecLife();
			if (Health.lifePoints <= 0){
				YouLose();
			} else {
				Ball.gameStarted = false;
			}
		} else {
			if (trigger.tag == "Ball"){
				Ball.nbBalls--;
			}
			Destroy (trigger.gameObject);
		}
	}

	void ResetPaddle(){
		paddle.tag = "Paddle";
		paddle.GetComponent<SpriteRenderer>().sprite = Paddle.paddleSprites[4];
		paddle.transform.localScale = new Vector3 (1.5f, paddle.transform.localScale.y, paddle.transform.localScale.z);
		Paddle.size = 0.75f;
	}

	void YouLose(){
		Bricks.bricksCount = 0;
		levelManager.LoadLevel("Lose");
		Ball.gameStarted = false;
		Health.lifePoints = 3;
	}
}
