using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinCounter : MonoBehaviour {

	private bool ballOutOfPlay = false;
	private int lastStandingCount = -1;
	private float lastTimeChange;
	private int lastSettledCount = 10;
	private GameManager gameManager;

	// Use this for initialization
	void Start () {
		gameManager = FindObjectOfType<GameManager>();
	}

	// Update is called once per frame
	void Update ()
	{
		if (ballOutOfPlay) {
			UpdateStandingCount ();
		}		
	}

	public int CountPins(){
		int count = 0;
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()){
			if (pin.isStanding()){
				count++;
			}
		}
		return count;
	}

	void UpdateStandingCount ()
	{

		int count = CountPins ();
		if (lastStandingCount != count) {
			lastStandingCount = count;
			lastTimeChange = Time.time;
			return;
		}

		if (Time.time - lastTimeChange > 3f){
			PinsHaveSettled();
		}
	}

	void PinsHaveSettled(){

		int count = CountPins();
		int pinFall = lastSettledCount - count;
		lastSettledCount = count;
		lastStandingCount = -1;
		gameManager.Bowl(pinFall);
		ballOutOfPlay = false;
	}

	public void SetCount(){
		lastSettledCount = 10;
	}

	void OnTriggerExit(Collider coll){
		if (coll.gameObject.GetComponent<Ball>()){
			ballOutOfPlay = true;
		}
	}
}
