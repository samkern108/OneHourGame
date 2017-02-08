using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public static Text score;

	public void Start() {
		score = GameObject.Find ("Score").GetComponent<Text>();
	}

	public static void SetScore(float enemiesExploded) {
		score.text = enemiesExploded + "";
	}
}
