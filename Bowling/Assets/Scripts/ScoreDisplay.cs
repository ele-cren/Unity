using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

	public Text[] rollTexts, frameTexts;

	public void FillRolls (List<int> rolls)
	{
		for (int i = 0; i < rolls.Count; i++) {
			if (i % 2 == 0 && i < 18 && rolls [i] == 10) {
				i++;
				rollTexts [i].text = "X";
			} else if (i % 2 != 0 && rolls [i] + rolls [i - 1] >= 10) {
				rollTexts [i].text = "/";
			} else {
				rollTexts[i].text = rolls[i].ToString();
			}
		}
	}

	public void FillFrames (List<int>frames)
	{
		for (int i = 0; i < frames.Count; i++) {
			frameTexts[i].text = frames[i].ToString();
		}
	}
}
