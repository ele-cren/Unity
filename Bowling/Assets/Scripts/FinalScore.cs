using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour {

	public Text score;

	// Use this for initialization
	void Start () {
		score.text = "You scored : " + ScoreDisplay.totalScore;
	}
}
