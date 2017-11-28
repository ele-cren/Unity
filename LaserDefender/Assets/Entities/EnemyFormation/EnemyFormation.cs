using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFormation : MonoBehaviour {

	public float moveSpeed = 3f;

	public GameObject enemyPrefab;

	private float xMin, xMax, padding = 0.5f;

	public float width = 10f, height = 5f;

	public float spawnDelay = 0.5f;

	bool movingRight = true;
	
	// Use this for initialization
	void Start () {

		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftmost = Camera.main.ViewportToWorldPoint (new Vector3(0, 0, distance));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint (new Vector3(1, 0, distance));
		xMin = leftmost.x - padding;
		xMax = rightmost.x + padding;

		SpawnUntilFull();
	}

	void SpawnEnnemies ()
	{
		foreach (Transform child in transform){
			GameObject enemy = Instantiate (enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = child;
		}
	}

	void SpawnUntilFull ()
	{
		Transform freePos = NextFreePosition ();
		if (freePos) {
			GameObject enemy = Instantiate (enemyPrefab, freePos.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = freePos;
		}
		if (NextFreePosition ()) {
			Invoke ("SpawnUntilFull", spawnDelay);
		}
	}

	public void OnDrawGizmos ()
	{
		Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
	}
	
	// Update is called once per frame
	void Update ()
	{
		MoveFormation ();
		if (AllMembersDead ()) {
			SpawnUntilFull();
		}
	}

	void MoveFormation ()
	{
		if (movingRight) {
			transform.position += Vector3.right * moveSpeed * Time.deltaTime;
		} else {
			transform.position += Vector3.left * moveSpeed * Time.deltaTime;
		}
		if (transform.position.x + width / 2 >= xMax) {
				movingRight = false;
		} else if (transform.position.x - width / 2 <= xMin) {
				movingRight = true;
		}
	}

	Transform NextFreePosition ()
	{
		foreach (Transform child in transform) {
			if (child.childCount <= 0) {
				return child;
			}
		}
		return null;
	}

	bool AllMembersDead ()
	{
		foreach (Transform child in transform) {
			if (child.childCount > 0) {
				return false;
			}
		}
		return true;
	}
}
