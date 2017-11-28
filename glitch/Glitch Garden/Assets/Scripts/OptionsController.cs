using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsController : MonoBehaviour {

	public Slider volumeSlider, difficultySlider;

	private MusicPlayer musicPlayer;

	// Use this for initialization
	void Start () {
		musicPlayer = FindObjectOfType<MusicPlayer>();
		volumeSlider.value = PlayerPrefsManager.GetVolume();
	}
	
	// Update is called once per frame
	void Update () {
		musicPlayer.ChangeVolume(volumeSlider.value);
		print (PlayerPrefsManager.GetVolume());
	}

	public void Default(){
		volumeSlider.value = 0.5f;
		difficultySlider.value = 2f;
	}

	public void SaveAndQuit(){
		PlayerPrefsManager.SetVolume(volumeSlider.value);
		PlayerPrefsManager.SetDifficulty(difficultySlider.value);
		SceneManager.LoadScene("01a Start");
	}
}
