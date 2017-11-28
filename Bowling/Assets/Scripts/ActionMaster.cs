using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ActionMaster {
	public enum Action {Tidy, Reset, EndTurn, EndGame, Undefined};

	public static Action NextAction (List<int> rolls)
	{
		Action currentAction = Action.Undefined;
		for (int i = 0; i < rolls.Count; i++) {
			if (i == 20) {
				currentAction = Action.EndGame;
			} else if (i >= 18 && rolls [i] == 10) {
				currentAction = Action.Reset;
			} else if (i == 18 && rolls [i] < 10) {
				currentAction = Action.Tidy;
			} else if (i == 19 && (rolls [18] + rolls [19]) % 10 == 0) {
				if (rolls [19] == 0) {
					currentAction = Action.Tidy;
				} else {
					currentAction = Action.Reset;
				}
			} else if (i == 19 && (rolls [18] + rolls [19] % 10) != 0) {
				if (rolls [18] + rolls [19] > 10) {
					currentAction = Action.Tidy;	
				} else {
					currentAction = Action.EndGame;
				}
			} else if (i % 2 == 0) {
				if (rolls [i] == 10) {
					currentAction = Action.EndTurn;
				} else {
					currentAction = Action.Tidy;
				}
			} else if (i % 2 != 0){
				currentAction = Action.EndTurn;
			}
		}
		return currentAction;
	}
}
