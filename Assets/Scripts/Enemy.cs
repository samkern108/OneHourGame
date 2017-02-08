using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	private float speed;
	private static int enemiesExploded = 0;
	private Vector3 moveVector;

	public GameObject explosionPrefab;

	public void Initialize(Vector3 moveToward) {

		// Set a random size for the enemies to make things more interesting!
		float size = Random.Range (.5f, 2.0f);
		transform.localScale = new Vector2 (size, size);

		// Bigger enemies are slightly transparent.
		Color color = GetComponent <SpriteRenderer> ().color;
		color.a = size.Map (0.5f, 2.0f, 1.0f, 0.7f);
		GetComponent <SpriteRenderer>().color = color;

		// Bigger enemies move more slowly.
		speed = Random.Range (0.7f/size, 1.0f/size);
		moveVector = moveToward * -speed;
	}

	void Update () {
		Move ();
	}

	private void Move() {
		transform.position += moveVector * Time.deltaTime;
	}

	public void OnCollisionEnter2D(Collision2D col) {

		Destroy (col.gameObject);

		enemiesExploded++;
		UIManager.SetScore (enemiesExploded);

		GameObject explosion = Instantiate (explosionPrefab);
		explosion.transform.position = this.transform.position;

		Destroy (gameObject);
	}

	// Destroy the missile when no camera can see it any longer.
	public void OnBecameInvisible() {
		Destroy (this.gameObject);
	}
}
