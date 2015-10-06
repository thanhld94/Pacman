using UnityEngine;
using System.Collections;

public class PacDotBehavior : MonoBehaviour {

	static private int mScore = -2;

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Player") {
			mScore++;
			Destroy(gameObject);
		}
	}

	public static int GetScore() {
		return mScore;
	}
}
