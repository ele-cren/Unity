using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinSetter : MonoBehaviour {

	private Animator animator;
	private PinCounter pinCounter;
	public GameObject pins;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		pinCounter = FindObjectOfType<PinCounter>();
	}

	public void PerformAction(ActionMaster.Action action){
		if (action == ActionMaster.Action.Tidy){
			animator.SetTrigger("tidyTrigger");
		} else if (action == ActionMaster.Action.Reset){
			animator.SetTrigger("resetTrigger");
			pinCounter.SetCount();
		} else if (action == ActionMaster.Action.EndTurn){
			animator.SetTrigger("resetTrigger");
			pinCounter.SetCount();
		} else if (action == ActionMaster.Action.EndGame){
			Time.timeScale = 0f;
		}
	}

	public void RaisePins(){
		foreach (Pin pin in FindObjectsOfType<Pin>()){
			pin.Raise();
		}
	}

	public void LowerPins(){
		foreach (Pin pin in FindObjectsOfType<Pin>()){
			pin.Lower();
		}
	}

	public void RenewPins(){
		Instantiate(pins, new Vector3(0, 30, 1829), Quaternion.identity);
	}
}
