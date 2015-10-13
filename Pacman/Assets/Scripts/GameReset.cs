using UnityEngine;
using System.Collections;

public class GameReset : MonoBehaviour {

	private float mTimer;
	public float ResetCountdown = 2f;

	void Start () {
		mTimer = ResetCountdown;
	}
	
	void Update () {
		if (mTimer > 0) 
			mTimer -= Time.deltaTime;
		else 
			Application.LoadLevel("GameScene");
	}
}
