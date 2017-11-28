using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

	public static GameObject selectedDefender;
	public GameObject prefabs;
	private GameObject thisButton = null;
	private Stars stars;
	// Use this for initialization
	void Start () {
		stars = FindObjectOfType<Stars>();
	}
	
	// Update is called once per frame
	void Update () {
		if (thisButton)
		{
			if (stars.starsAmount >= selectedDefender.GetComponent<Defender>().starsCost){
				thisButton.GetComponent<SpriteRenderer>().color = Color.white;
			} else {
				thisButton.GetComponent<SpriteRenderer>().color = Color.red;
			}
		}
	}

	void OnMouseDown(){
		Button[] allButtons = GameObject.FindObjectsOfType<Button>();


		foreach (Button button in allButtons){
			button.GetComponent<SpriteRenderer>().color = Color.black;
			button.thisButton = null;
		}
		selectedDefender = prefabs;
		thisButton = gameObject;
	}
}
