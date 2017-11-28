using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bricks : MonoBehaviour {

	public AudioClip crack;

	private LevelManager levelManager;

	public Sprite[] hitSprites;

	private GameObject bonus;

	public static int bricksCount = 0;

	private int timesHit;

	private bool isTouch = false;

	// Use this for initialization
	void Start ()
	{
		bonus = GameObject.Find("Bonus");
		levelManager = FindObjectOfType<LevelManager> ();
		if (this.tag != "Unbreakable") {
			bricksCount++;
		}
		timesHit = 0;
	}

	void OnTriggerEnter2D(Collider2D trigger){
		bool isBreakable = (this.tag != "Unbreakable");
		if (isBreakable && trigger.tag == "Fireball" && isTouch == false) {
			HandleHits();
			Destroy (trigger.gameObject);
		} else if (isBreakable && trigger.tag == "Rocket"){
			OnBrickDestroy();
			Destroy (trigger.gameObject);
		} else if (trigger.tag == "Rocket" || trigger.tag == "Fireball"){
			Destroy (trigger.gameObject);
		}
	}

	void OnCollisionEnter2D (Collision2D coll)
	{
		bool isBreakable = (this.tag != "Unbreakable");
		if (isBreakable && isTouch == false) {
			HandleHits();
		}
	}

	void Update(){
		if (isTouch == true){
			isTouch = false;
		}
	}

	void HandleHits ()
	{
		isTouch = true;
		timesHit++;
		int maxHits = hitSprites.Length + 1;
		if (timesHit >= maxHits) {
			OnBrickDestroy();
		} else {
			LoadSprites();
		}
	}

	void OnBrickDestroy(){
		AudioSource.PlayClipAtPoint(crack, transform.position);
		bricksCount--;
		if (gameObject.tag == "Life"){
			GameObject go = Instantiate(Resources.Load("Prefabs/BonusHeart", typeof(GameObject)), transform.position, Quaternion.identity) as GameObject;
			go.transform.parent = bonus.transform;
		} else if (gameObject.tag == "Laser"){
			GameObject go = Instantiate(Resources.Load("Prefabs/Laser", typeof(GameObject)), transform.position, Quaternion.identity) as GameObject;
			go.transform.parent = bonus.transform;		
		} else if (gameObject.tag == "Rocket"){
			GameObject go = Instantiate(Resources.Load("Prefabs/Rocket Launcher", typeof(GameObject)), transform.position, Quaternion.Euler(0, 0, 40)) as GameObject;
			go.transform.parent = bonus.transform;		
		} else if (gameObject.tag == "Enlarge"){
			GameObject go = Instantiate(Resources.Load("Prefabs/Enlarge", typeof(GameObject)), transform.position, Quaternion.identity) as GameObject;
			go.transform.parent = bonus.transform;		
		} else if (gameObject.tag == "Mult"){
			GameObject go = Instantiate(Resources.Load("Prefabs/Mult", typeof(GameObject)), transform.position, Quaternion.identity) as GameObject;
			go.transform.parent = bonus.transform;		
		}
		levelManager.BrickDestroy ();
		Destroy (gameObject);
	}

	void LoadSprites ()
	{
		int spriteIndex = timesHit - 1;

		if (hitSprites [spriteIndex]) {
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}
	}
}
