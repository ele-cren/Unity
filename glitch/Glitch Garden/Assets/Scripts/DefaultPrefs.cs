using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultPrefs : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (!PlayerPrefs.HasKey("master_volume")){
			PlayerPrefsManager.SetVolume(0.5f);
		}
		if (!PlayerPrefs.HasKey("difficulty")){
			PlayerPrefsManager.SetDifficulty(2f);
		}
	}
}
