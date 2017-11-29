﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour {

	private PinSetter pinSetter;
	private List<int> rolls = new List<int>();
	private Ball ball;
	private ScoreDisplay scoreDisplay;
	public bool play = true;

	// Use this for initialization
	void Start () {
		pinSetter = GameObject.FindObjectOfType<PinSetter>();
		ball = FindObjectOfType<Ball>();
		scoreDisplay = FindObjectOfType<ScoreDisplay>();
	}

	public void Bowl (int pinFall)
	{

		rolls.Add (pinFall);
		if (pinFall == 10 && rolls.Count - 1 < 18 && ((rolls.Count - 1) % 2 == 0)) {
			rolls.Add (0);
		}
		scoreDisplay.FillRolls (rolls);
		scoreDisplay.FillFrames (ScoreMaster.ScoreFrame (rolls));

		pinSetter.PerformAction (ActionMaster.NextAction (rolls));
		if (play) {
			ball.Reset();
		}
	}
}
