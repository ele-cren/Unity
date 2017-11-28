using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bonus : MonoBehaviour {

	private GameObject[] bricks;

	// Use this for initialization
	void Start () {
		
		bricks = GameObject.FindGameObjectsWithTag("Breakable");

		ChooseBonus();
	}
	
	void ChooseBonus(){
		int nbBonus;

		nbBonus = SceneManager.GetActiveScene().buildIndex;

		for (int i = 0; i < nbBonus; i++){
			int nbBrick = GetBrick();
			if (nbBrick != -1){
				int rand = Random.Range(1, 6);
				if (rand == 1){
					bricks[nbBrick].tag = "Life";
				} else if (rand == 2){
					bricks[nbBrick].tag = "Enlarge";
				} else if (rand == 3){
					bricks[nbBrick].tag = "Laser";
				} else if (rand == 4){
					bricks[nbBrick].tag = "Rocket";
				} else if (rand == 5){
					bricks[nbBrick].tag = "Mult";
				}
			}
		}
	}

	int GetBrick(){
		for (int i = 0; i < bricks.Length; i++){
			int nbBrick = Random.Range(0, bricks.Length);
			if (bricks[nbBrick].tag == "Breakable"){
				return nbBrick;
			}
		}
		return -1;
	}

	// Update is called once per frame
	void Update () {
		
	}
}
