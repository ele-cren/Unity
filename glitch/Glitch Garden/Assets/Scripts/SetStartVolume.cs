using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStartVolume : MonoBehaviour {

	private MusicPlayer musicPlayer;

	// Use this for initialization
	void Start () {
		
		musicPlayer = FindObjectOfType<MusicPlayer>();
		if (musicPlayer){
			musicPlayer.ChangeVolume(PlayerPrefsManager.GetVolume());
		} else {
			Debug.LogWarning("There is no Music Player in the scene.");
		}
	}	
}
