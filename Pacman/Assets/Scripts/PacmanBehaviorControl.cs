using UnityEngine;
using System.Collections;

public class PacmanBehaviorControl : MonoBehaviour {

	public float Speed = 0.4f;
	public LayerMask WhatIsWall;

	private Rigidbody2D mRigidbody2D;
	private Animator mAnimator;

	private float mRadius;
	private Vector2 mDestination;
	private Vector2 mDirection;

	void Start () {
		mRigidbody2D = GetComponent <Rigidbody2D>();
		mAnimator = GetComponent <Animator>();
		mDestination = transform.position;
		mRadius = GetComponent <CircleCollider2D>().radius;
	}
	
	void FixedUpdate () {
		Vector2 p = Vector2.MoveTowards (transform.position, mDestination, Speed);
		mRigidbody2D.MovePosition (p); 

		if ((Vector2) transform.position == mDestination) {
			mDirection = Vector2.zero;
			if (Input.GetKey (KeyCode.UpArrow))
				mDirection = Vector2.up;
			if (Input.GetKey (KeyCode.DownArrow))
				mDirection = Vector2.down;
			if (Input.GetKey (KeyCode.LeftArrow))
				mDirection = Vector2.left;
			if (Input.GetKey (KeyCode.RightArrow))
				mDirection = Vector2.right;
			if (IsValidMove(mDirection))
				mDestination = (Vector2)transform.position + mDirection;
			else
				mDestination = transform.position;
		}

		mAnimator.SetFloat("DirX", mDirection.x);
		mAnimator.SetFloat("DirY", mDirection.y);
	}


	// Check if the next move in the "dir" direction is valid or not
	// by casting a linecast from the current position to the next position pos + dir
	// if the line does not intersect a wall layer then return true (valid move)
	bool IsValidMove(Vector2 dir) {
		Vector2 pos = transform.position;
		GetComponent <CircleCollider2D>().enabled = false;

		bool isValid = (Physics2D.OverlapCircle(pos + dir, mRadius, WhatIsWall) == null);
		return isValid;
	}
	
	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Pacdot") {
			UnityEngine.Debug.Log ("ate");
		}
	}
}
