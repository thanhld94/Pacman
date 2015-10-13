using UnityEngine;
using System.Collections;

public class RandomGhostBehavior : MonoBehaviour {

	private Rigidbody2D mBody2D;
	private Animator mAnimator;
	private Vector2 mDirection;
	private Vector2 mDestination;
	private float mRadius;

	private float Speed = 0.4f;
	public LayerMask WhatIsWall;
	private Vector2[] mDirs = new Vector2[] {Vector2.up, Vector2.down, Vector2.left, Vector2.right};


	public void DestroyRed() {
		Destroy(gameObject);
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			other.SendMessageUpwards("GameOver");
		}
	}

	void Start () {
		mAnimator = GetComponent<Animator>();
		mBody2D = GetComponent<Rigidbody2D>();
		mBody2D.freezeRotation = true;
		mDestination = transform.position;
		mRadius = GetComponent <CircleCollider2D>().radius;
		mDirection = mGetRandomDirection(transform.position);

	}
	
	void FixedUpdate () {
		Vector2 p = Vector2.MoveTowards (transform.position, mDestination, Speed);
		mBody2D.MovePosition (p); 
		if ((Vector2) transform.position == mDestination) {
			if (!IsValidMove(transform.position, mDirection)) 
				mDirection = mGetRandomDirection(transform.position);
			mDestination = (Vector2)transform.position + mDirection;
		}
		
		mAnimator.SetFloat("DirX", mDirection.x);
		mAnimator.SetFloat("DirY", mDirection.y);
	}

	private Vector2 mGetRandomDirection(Vector2 pos) {
		ArrayList moveList = new ArrayList();
		for (int i = 0; i < mDirs.Length; i++) {
			if (IsValidMove(pos, mDirs[i]))
				moveList.Add (mDirs[i]);
		}
		Vector2 result = (Vector2) moveList[(int)Random.Range(0,moveList.Count)];
		return result;
	}

	// Check if the next move in the "dir" direction is valid or not
	// by casting a linecast from the current position to the next position pos + dir
	// if the line does not intersect a wall layer then return true (valid move)
	private bool IsValidMove(Vector2 pos, Vector2 dir) {
		GetComponent <CircleCollider2D>().enabled = false;
		bool isValid = (Physics2D.OverlapCircle(pos + dir, mRadius, WhatIsWall) == null);
		GetComponent <CircleCollider2D>().enabled = true;
		return isValid;
	}
}
