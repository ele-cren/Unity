using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour {

	private Stars stars;
	public int starsCost = 15;

	void Start(){
		stars = GameObject.FindObjectOfType<Stars>();
	}

	void AddStars(int amount){
		stars.AddStars(amount);
	}
}
