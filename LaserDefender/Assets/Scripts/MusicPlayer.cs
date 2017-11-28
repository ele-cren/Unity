using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour {

	public static bool isDead = false;

	public static MusicPlayer instance = null;

	public AudioClip start, game, death;

	private AudioSource music;

	void Awake(){
		if (instance != null){
			Destroy (gameObject);
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
			music = GetComponent<AudioSource>();
			music.clip = start;
			music.loop = true;
			music.Play();
		}
	}

	void OnEnable ()
	{
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	void OnDisable ()
	{
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}

	void OnSceneLoaded (Scene scene, LoadSceneMode mode)
	{
		music.Stop ();
		if (SceneManager.GetActiveScene ().buildIndex == 0) {
			isDead = false;
			music.clip = start;
		} else if (SceneManager.GetActiveScene ().buildIndex == 1) {
			if (!isDead) {
				music.clip = game;
			} else {
				music.clip = death;
			}
		}

		music.loop = true;
		music.Play();
	}

}
