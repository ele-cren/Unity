using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

	public int[] defaultEnemies;
	private int[] enemiesPerWave;
	private int max = 0;
	private float rate, nextSpawn = 3.00f;
	private bool[] laneChosen = new bool[] { false, false, false, false, false };
	public GameObject[] enemyPrefabs;
	private int maxPercent;

	// Use this for initialization
	void Start () {
		enemiesPerWave = new int[defaultEnemies.Length];
		System.Array.Copy(defaultEnemies, enemiesPerWave, defaultEnemies.Length);
		max = GetMax();
		GetPercent();
	}

	int GetMax(){
		for (int i = 0; i < enemiesPerWave.Length; i++){
			if (enemiesPerWave[i] > 0){
				max = i;
			}
		}
		return enemiesPerWave[max];
	}

	void GetPercent(){
		foreach (GameObject enemy in enemyPrefabs){
			maxPercent += enemy.GetComponent<Attacker>().spawnProb;
		}
	}

	// Update is called once per frame
	void Update () {
		if (Time.timeSinceLevelLoad > nextSpawn && !GameTimer.gameIsFinished){
			rate = Random.Range(3f, 6f);
			nextSpawn = Time.timeSinceLevelLoad + rate;
			ChooseWave();
		}
		if (GetMax() == 0){
			System.Array.Copy(defaultEnemies, enemiesPerWave, defaultEnemies.Length);
			max = GetMax();
		}
	}

	void ChooseWave(){
		int randWave = Random.Range(0, max + 1);
		while (enemiesPerWave[randWave] == 0){
			randWave = Random.Range(0, max + 1);
		}
		for (int i = 0; i <= randWave; i++){
			SpawnEnemy();
		}
		enemiesPerWave[randWave] -= 1;
		laneChosen = new bool[] { false, false, false, false, false };
	}

	void SpawnEnemy(){
		GameObject enemyToSpawn = GetEnemy();
		int randLane = Random.Range(0, 5);
		while (laneChosen[randLane] == true){
			randLane = Random.Range(0, 5);
		}
		laneChosen[randLane] = true;
		Vector2 pos = transform.GetChild(randLane).transform.position;
		GameObject attacker = Instantiate(enemyToSpawn, pos, Quaternion.identity) as GameObject;
		attacker.transform.parent = transform.GetChild(randLane).transform;
	}

	GameObject GetEnemy(){
		GameObject enemyChosen = null;

		int rand = Random.Range(0, maxPercent + 1);
		int times;

		times = 0;
		foreach (GameObject enemy in enemyPrefabs){
			int percent = enemy.GetComponent<Attacker>().spawnProb;
			times += percent;
			if (rand <= times){
				enemyChosen = enemy;
				return enemyChosen;
			}
		}
		return null;
	}
}
