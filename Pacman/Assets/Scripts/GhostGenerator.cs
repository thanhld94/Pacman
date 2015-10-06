using UnityEngine;
using System.Collections;

public class GhostGenerator : MonoBehaviour {

	public GameObject RedGhost;
	private Vector2 mRedBoxPos = new Vector2(14,17);

	// Use this for initialization
	void Start () {
		Instantiate(RedGhost, mRedBoxPos, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
	}
}
