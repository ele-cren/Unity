using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour {

	public static int lifeMax = 3;
	
	public static int  lifePoints = 3;

	public static  GameObject[] hearts;

	public static Sprite[] emptyHeart;

	// Use this for initialization
	void Start () {

		if (Resources.Load<Sprite>("Sprites/hearts")){
			emptyHeart = Resources.LoadAll<Sprite>("Sprites/hearts");
		}

		float inc = 0.5f;
		hearts = new GameObject[lifeMax];
		for (int i = 0; i < lifeMax; i++){
			GameObject go = Instantiate(Resources.Load("Prefabs/FullHeart", typeof(GameObject)), new Vector3(inc, 11.5f, 0f), Quaternion.identity) as GameObject;
			if (lifePoints - 1 < i){
				go.GetComponent<SpriteRenderer>().sprite = emptyHeart[0];
			}
			hearts[i] = go;
			inc += 1f;
		}
	}
	
	public void DecLife(){
		if (lifeMax > 3){
			Destroy (hearts[lifePoints - 1]);
			System.Array.Resize(ref hearts, hearts.Length - 1);
			lifeMax--;
		} else {
			hearts[lifePoints - 1].GetComponent<SpriteRenderer>().sprite = emptyHeart[0];
		}
		lifePoints--;
	}
}
