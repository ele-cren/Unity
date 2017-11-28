using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {

	private Text highScore;

	private ScoreKeeper scoreKeeper;

	// Use this for initialization
	void Start ()
	{
		scoreKeeper = FindObjectOfType<ScoreKeeper>();
		if (scoreKeeper.score >= ScoreKeeper.bestScore) {
			ScoreKeeper.bestScore = scoreKeeper.score;
		}
		highScore = GetComponent<Text>();
		highScore.text = "High Score : " + ScoreKeeper.bestScore;
	}

}
