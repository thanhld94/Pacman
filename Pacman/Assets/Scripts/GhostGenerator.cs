using UnityEngine;
using System.Collections;

public class GhostGenerator : MonoBehaviour {

	public GameObject RedGhost;
	public GameObject BlueGhost;
	public GameObject PinkGhost;
	//public GameObject OrangeGhost;

	private Vector2 mRedBoxPos = new Vector2(14,17);
	private Vector2 mBluePos = new Vector2(27, 30);
	private Vector2 mPinkPos = new Vector2(2, 28);
	//private Vector2 mOrangePos = new Vector2(28, 2);

	// Use this for initialization
	void Start () {
		Instantiate(RedGhost, mRedBoxPos, Quaternion.identity);
		Instantiate(BlueGhost, mBluePos, Quaternion.identity);
		Instantiate(PinkGhost, mPinkPos, Quaternion.identity);
		//Instantiate(OrangeGhost, mOrangePos, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
	}
}
