using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public float autoLoad = 0;

	// Use this for initialization
	void Start () {
		if (autoLoad > 0){
			Invoke ("NextLevel", autoLoad);
		}
	}
	
	public void LoadLevel(string name){
		SceneManager.LoadScene(name);
	}

	public void NextLevel(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void Quit(){
		Application.Quit();
	}
}
