using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameBehavior : MonoBehaviour {

	private Text mScoreText;

	void Awake() {
		mScoreText = GameObject.Find("ScoreText").GetComponent<Text>();
	}

	void Update() {
		mScoreText.text = "Score: " + PacDotBehavior.GetScore();
	}
}
