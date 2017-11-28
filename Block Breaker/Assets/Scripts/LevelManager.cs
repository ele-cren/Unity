using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name){
		if (SceneManager.GetActiveScene ().name == "Start"){
			Health.lifePoints = 3;
		}
		SceneManager.LoadScene(name);
	}

	public void NextLevel ()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void Quit(){
		Application.Quit();
	}

	public void BrickDestroy(){
		if (Bricks.bricksCount <= 0){
			Ball.gameStarted = false;
			NextLevel();
		}
	}
}
