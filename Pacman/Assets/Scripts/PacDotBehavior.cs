using UnityEngine;
using System.Collections;

public class PacDotBehavior : MonoBehaviour {

	static private int mScore = 0;

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Player") {
			mScore++;
			Destroy(gameObject);
		}
	}

	public int GetScore() {
		return mScore;
	}
}
