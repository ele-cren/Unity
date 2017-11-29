using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextCount : MonoBehaviour {

	private PinCounter pinCounter;
	private Text text;
	private Animator pinAnimator;

	// Use this for initialization
	void Start () {
		pinCounter = FindObjectOfType<PinCounter>();
		text = GetComponent<Text>();
		pinAnimator = FindObjectOfType<PinSetter>().GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (pinAnimator.GetCurrentAnimatorStateInfo (0).IsName ("Idle")) {
			text.text = pinCounter.CountPins().ToString();
		}
	}
}
