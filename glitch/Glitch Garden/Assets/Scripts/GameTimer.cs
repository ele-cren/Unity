 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

	public float gameTime = 100;
	private Slider slider;
	public static bool gameIsFinished = false;
	private AudioSource music;
	public LevelManager levelManager;
	private GameObject win;
	private GameObject defenders;
	private GameObject spawner;

	// Use this for initialization
	void Start () {
		gameIsFinished = false;
		slider = GetComponent<Slider>();
		music = GetComponent<AudioSource>();
		win = GameObject.Find("Win");
	}
	
	// Update is called once per frame
	void Update () {
		slider.value = Time.timeSinceLevelLoad / gameTime;
		if (Time.timeSinceLevelLoad >= gameTime && !gameIsFinished){
			StopTheGame();
			gameIsFinished = true;
			music.Play();
			win.GetComponent<Text>().enabled = true;
			Invoke("NextLevel", music.clip.length);
		}
	}

	void NextLevel(){
		levelManager.NextLevel();
	}

	void StopTheGame(){
		defenders = GameObject.Find("Defenders");
		spawner = GameObject.Find("Spawner");
		if (defenders){
			foreach (Transform defender in defenders.transform){
				defender.GetComponent<Animator>().SetBool("isAttacking", false);
				defender.GetComponent<Animator>().SetBool("isIdle", true);
			}
		} else {
			Debug.LogWarning("You don't have a Defenders go.");
		}

		if (spawner){
			foreach (Transform lane in spawner.transform){
				foreach (Transform enemy in lane){
					enemy.GetComponent<Animator>().SetBool("isIdle", true);
				}
			}
		} else {
			Debug.LogWarning("You don't have a Spawner go.");
		}
	}
}
