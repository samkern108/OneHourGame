using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

	// Destroy ourselves after *just* long enough for the particle effect to finish.
	void Start () {
		GetComponent <AudioSource>().Play();
		Invoke("Die", .5f);
	}

	private void Die() {
		Destroy (this.gameObject);
	}
}
