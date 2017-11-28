using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetCost : MonoBehaviour {

	public GameObject defender;
	private Text cost;

	// Use this for initialization
	void Start () {
		cost = GetComponent<Text>();
		cost.text = defender.GetComponent<Defender>().starsCost.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
