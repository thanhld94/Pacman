using UnityEngine;
using System.Collections;

public class PacDotBehavior : MonoBehaviour {

	public bool triggered = false;

	void OnTriggerEnter2D (Collider2D other) {
		triggered = true;
		UnityEngine.Debug.Log ("entered collider");
		if (other.gameObject.tag == "Player")
			UnityEngine.Debug.Log ("pacman enter");
	}
}
