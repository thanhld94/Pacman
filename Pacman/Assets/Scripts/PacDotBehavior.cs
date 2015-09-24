using UnityEngine;
using System.Collections;

public class PacDotBehavior : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Player")
			Destroy(gameObject);
	}
}
