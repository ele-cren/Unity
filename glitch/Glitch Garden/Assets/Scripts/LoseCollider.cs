using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider){
		GameObject obj = collider.gameObject;
		if (obj.GetComponent<Fox>()){
			obj.GetComponent<Animator>().SetTrigger("Trigger Jump");
		} else {
			obj.GetComponent<Attacker>().SetSpeed(3f);
		}
		Invoke("LoadLose", 1f);
	}

	void LoadLose(){
		SceneManager.LoadScene("03b Lose");
	}
}
