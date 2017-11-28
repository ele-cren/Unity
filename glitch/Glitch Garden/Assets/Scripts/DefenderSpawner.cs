using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

	public Camera myCam;
	private GameObject defenderParent;
	private GameObject spawner;

	// Use this for initialization
	void Start () {
		spawner = GameObject.Find("Spawner");

		defenderParent = GameObject.Find("Defenders");
		if (!defenderParent){
			defenderParent = new GameObject("Defenders");
		}
	}

	Vector2 PositionToWorld(){
		float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;
		float distance = 10f;

		Vector3 weirdTriplet = new Vector3 (mouseX, mouseY, distance);
		return myCam.ScreenToWorldPoint(weirdTriplet);
	}

	void OnMouseDown(){
		Stars stars = GameObject.FindObjectOfType<Stars>();
		GameObject selected = Button.selectedDefender;
		if (selected){
			int cost = selected.GetComponent<Defender>().starsCost;
			Vector2 posToSpawn = RoundPos(PositionToWorld());
			if (PositionIsFree(posToSpawn) && !AttackerInside(posToSpawn)){
				if (selected.GetComponent<Stone>() && CheckGravestones(posToSpawn)){
					return ;
				}
				if (stars.UseStars(cost) == Stars.Status.SUCCESS){
					GameObject defender = Instantiate(selected, posToSpawn, Quaternion.identity);
					defender.transform.parent = defenderParent.transform;
				}
			}
		}
	}

	bool AttackerInside(Vector2 pos){
		foreach (Transform lane in spawner.transform){
			foreach (Transform attacker in lane){
				float attackerPosX = attacker.position.x - attacker.GetComponent<BoxCollider2D>().size.x / 2;
				if (pos.y == attacker.position.y && (attackerPosX > pos.x - 0.5f && attackerPosX < pos.x + 0.5f)){
					return true;
				}
			}
		}
		return false;
	}

	bool CheckGravestones(Vector2 pos){
		foreach (Transform def in defenderParent.transform){
			if (def.GetComponent<Stone>() && def.position.y == pos.y && (def.position.x == pos.x - 1 || def.position.x == pos.x + 1)){
				return true;
			}
		}
		return false;
	}

	public bool PositionIsFree(Vector2 pos){
		foreach (Transform def in defenderParent.transform){
			if (def.position.x == pos.x && def.position.y == pos.y){
				return false;
			}
		}
		return true;
	}

	Vector2 RoundPos(Vector2 pos){
		float mouseX = Mathf.RoundToInt(pos.x);
		float mouseY = Mathf.RoundToInt(pos.y);

		Vector2 newPos = new Vector2(mouseX, mouseY);
		return newPos;
	}
}
