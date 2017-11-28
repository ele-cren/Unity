using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent (typeof(AudioSource))]
public class MusicPlayer : MonoBehaviour {

	public AudioClip[] songs;
	private AudioSource music;


	void OnEnable(){
		SceneManager.sceneLoaded += LevelLoaded;
	}

	void OnDisable(){
		SceneManager.sceneLoaded -= LevelLoaded;
	}

	void Awake(){
		DontDestroyOnLoad(gameObject);
	}

	void LevelLoaded(Scene scene, LoadSceneMode mode){
		music = GetComponent<AudioSource>();
		music.loop = true;
		if (songs[SceneManager.GetActiveScene().buildIndex]){
			music.clip = songs[SceneManager.GetActiveScene().buildIndex];
			music.Play();
		}
	}

	public void ChangeVolume(float volume){
		PlayerPrefsManager.SetVolume(volume);
		music.volume = volume;
	}
}
