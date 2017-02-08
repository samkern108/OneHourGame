using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	private float secondsBetweenSpawn = .4f;
	public GameObject enemyPrefab;

	void Start () {
		// Spawn an enemy every "secondsBetweenSpawn" seconds
		InvokeRepeating ("Spawn", .5f, secondsBetweenSpawn);
	}

	private void Spawn() {
		GameObject enemy = Instantiate (enemyPrefab);
		float randomAngle = Random.Range(0f, Mathf.PI * 2f);

		// Get a point on the edge of a circle. This is also the direction in which our enemy needs to move to reach the hero.
		Vector3 spawnPos = new Vector2(Mathf.Sin(randomAngle), Mathf.Cos(randomAngle)).normalized;

		// Move the spawnPosition well outside the camera and add it to the spawner's current position.
		Vector3 spawnPosition = this.transform.position + (spawnPos * 8.0f); 
		enemy.transform.position = spawnPosition;

		// Initialize the enemy with its movement vector.
		enemy.GetComponent <Enemy>().Initialize(spawnPos);
	}
}
