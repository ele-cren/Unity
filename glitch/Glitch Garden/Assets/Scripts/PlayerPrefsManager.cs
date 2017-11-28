using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour {

	const string MASTER_VOLUME_KEY = "master_volume";
	const string DIFFICULTY_KEY = "difficulty";
	const string LEVEL_KEY = "level_unlocked_";

	public static void SetVolume(float volume){
		if (volume >= 0f && volume <= 1f){
			PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
		} else {
			Debug.LogError("The volume is not between 0 and 1.");
		}
	}

	public static float GetVolume(){
		return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
	}

	public static void SetDifficulty(float difficulty){
		if (difficulty >= 1f && difficulty <= 3f){
			PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
		} else {
			Debug.LogError("The difficulty is not between 1 and 3.");
		}
	}

	public static float GetDifficulty(){
		return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
	}
 
	public static void UnlockLevel(int level){
		if (level >= 3 && level <= SceneManager.sceneCount - 1){
			PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1);
		} else {
			Debug.LogError("The level is not in the build settings.");
		}
	}

	public static void LockLevel(int level){
		if (level >= 3 && level <= SceneManager.sceneCount - 1){
			PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 0);
		} else {
			Debug.LogError("The level is not in the build settings.");
		}
	}
}
