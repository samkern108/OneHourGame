using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour {

	private float fireRate = 0.2f;
	private float speed = 450f;
	public GameObject missilePrefab;

	public void Start() {
		// There aren't any drawbacks to just spamming the spacebar, so I just made it fire repeatedly. :)
		// The way to get the spacebar press information is Input.GetKeyDown(Keycode.Space)
		InvokeRepeating("Fire", fireRate, fireRate);
	}

	void Update () {
		//The "Horizontal" axis is predefined in Unity's default input settings (Edit -> Project Settings -> Input)
		Move(Input.GetAxis ("Horizontal"));
	}

	private void Move(float input) {
		// We rotate around our parent transform ("Planet")'s position on the z (0,0,1) axis
		transform.RotateAround(transform.parent.position, new Vector3(0,0,1), -input * Time.deltaTime * speed);
	}

	private void Fire() {
		GetComponent <Animator>().SetTrigger("Shoot");

		// Instantiate a missile gameobject and set its initial position to *our* position.
		GameObject missile = Instantiate (missilePrefab);
		missile.transform.position = this.transform.position;

		// transform.up refers to the direction the gameobject is facing, in this case, the hero sprite.
		missile.GetComponent <Missile>().Initialize(transform.up);
	}
}
