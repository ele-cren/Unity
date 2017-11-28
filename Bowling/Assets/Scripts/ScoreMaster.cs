using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class ScoreMaster {

	public static List<int> ScoreFrame(List<int> rolls)
	{
		List<int> scores = new List<int>();
		int index = 0;

		for (int i = 0; i < rolls.Count; i++){
			if (i % 2 == 0){ // First roll of a frame

			// Putting 0 after Strike so -> i + 4 is the second roll after strike skiping two 0 (Because two strikes)
			// and i + 3 is second roll after strike skiping 0 (only one strike)

				if (i < 18 && rolls[i] == 10){ // Strike (18 is the begining of the last frame -> Special cases)
					if (( i + 4 < rolls.Count && rolls[i + 2] == 10) ||    // We can score the frame (2 rolls after strike)
							(i + 3 < rolls.Count && rolls[i + 2] != 10)){
						if (rolls[i + 2] == 10 && i + 2 < 18){scores.Add((index == 0) ? 10 + rolls[i + 2] + // Second roll Strike
								rolls[i + 4] : 10 + rolls[i + 2] + rolls[i + 4] + scores[index - 1]);
						} else {scores.Add((index == 0) ? 10 + rolls[i + 2] + rolls[i + 3] : 10 + // Second roll not Strike
								rolls[i + 2] + rolls[i + 3] + scores[index - 1]);}
						index++;
					}
				} else if (i == 20){ // Last roll
					scores.Add(rolls[i] + rolls[i - 1] + rolls[i - 2] + scores[index - 1]);
				}

			} else if (i % 2 != 0){ // Second roll of a frame
				if (rolls[i] + rolls[i - 1] == 10 && rolls[i - 1] != 10 && i + 1 < rolls.Count && i != 19){ // Spare
					scores.Add((index == 0) ? 10 + rolls[i + 1] : 10 + rolls[i + 1] + scores[index - 1]);
					index++;
				} else if ((i != 19 || (i == 19 && rolls[i] + rolls[i - 1] < 10)) // open frame
						&& rolls[i - 1] != 10 && rolls[i] + rolls[i - 1] < 10){ 
					scores.Add((index == 0) ? rolls[i] + rolls[i - 1] : rolls[i] + rolls[i - 1] + scores[index - 1]);
					index++;
				}
			}
		}
		return scores;
	}
}