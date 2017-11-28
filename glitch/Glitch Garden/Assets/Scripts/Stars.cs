using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stars : MonoBehaviour {

	public int starsAmount = 100;
	private Text starsDisplay;
	public enum Status {SUCCESS, FAILURE};

	// Use this for initialization
	void Start () {
		starsDisplay = GetComponent<Text>();
		UpdateDisplay();
	}
	
	public void AddStars(int amount){
		starsAmount += amount;
		UpdateDisplay();
	}

	public Status UseStars(int amount){
		if (starsAmount >= amount){
			starsAmount -= amount;
			UpdateDisplay();
			return Status.SUCCESS;
		}
		return Status.FAILURE;
	}

	void UpdateDisplay(){
		starsDisplay.text = starsAmount.ToString();
	}
}
