using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

	public static int bestScore = 0;

	public int score;

	private Text text;

	void Start(){
		text = GetComponent<Text>();
		Reset();
	}

	public void ScorePoints(int points){
		score += points;
		text.text = "Score : " + score;
	}

	public void Reset ()
	{
		score = 0;
		text.text = "Score : " + score;
	}
}
