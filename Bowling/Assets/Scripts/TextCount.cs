using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextCount : MonoBehaviour {

	private PinCounter pinCounter;
	private Text text;

	// Use this for initialization
	void Start () {
		pinCounter = FindObjectOfType<PinCounter>();
		text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		text.text = pinCounter.CountPins().ToString();
	}
}
