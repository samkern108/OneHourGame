using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour {

	private float speed = 10.0f;
	private Vector3 moveVector;

	public void Initialize(Vector3 direction) {
		moveVector = direction * speed;
	}

	void Update () {
		transform.position += (moveVector * Time.deltaTime);
	}

	// Destroy the missile when no camera can see it any longer.
	public void OnBecameInvisible() {
		Destroy (this.gameObject);
	}
}
