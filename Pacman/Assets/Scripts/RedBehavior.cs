using UnityEngine;
using System.Collections;

public class RedBehavior : MonoBehaviour {

	private Rigidbody2D mBody2D;
	private Animator mAnimator;
	private PacmanBehaviorControl mPacman;

	private float mRadius;
	private Vector2 mDestination;
	private Vector2 mTarget;
	private Vector2 mDirection;

	private float Speed = 0.4f;
	public LayerMask WhatIsWall;
	private Vector2[] mDirs = new Vector2[] {Vector2.up, Vector2.down, Vector2.left, Vector2.right};

	private Queue mQueue;
	private int INF = 100000;

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
		mPacman = GameObject.Find ("Pacman").GetComponent<PacmanBehaviorControl>();
		mBody2D.freezeRotation = true;
		mDestination = transform.position;
		mRadius = GetComponent <CircleCollider2D>().radius;
		mQueue = new Queue();
	}
	
	void FixedUpdate () {
		Vector2 p = Vector2.MoveTowards (transform.position, mDestination, Speed);
		mBody2D.MovePosition (p); 
		
		if ((Vector2) transform.position == mDestination && mQueue.Count == 0) {
			//UnityEngine.Debug.Log ("Pos = " + transform.position);
			mDirection = Vector2.zero;
			int result = INF;
			for ( int i = 0; i < mDirs.Length; i++ )
				if (IsValidMove(transform.position, mDirs[i]))
					if (result > MinDistance((Vector2)transform.position + mDirs[i], mPacman.GetPosition())) {
						//UnityEngine.Debug.Log ("This dir = " + mDirs[i]);
						result = MinDistance((Vector2)transform.position + mDirs[i], mPacman.GetPosition());
						mDirection = mDirs[i];
					}

					
			mDestination = (Vector2)transform.position + mDirection;

		}
		
		mAnimator.SetFloat("DirX", mDirection.x);
		mAnimator.SetFloat("DirY", mDirection.y);
	}

	private int MinDistance(Vector2 st, Vector2 fin) {
		if (mQueue.Count != 0) return -1;
		mQueue.Enqueue(st);
		int[][] d = new int[50][];
		for ( int i = 0; i < d.Length; i++ )
			d[i] = new int[50];
		d[(int)st.x][(int)st.y] = 1;
		while (mQueue.Count != 0) {
			Vector2 top = (Vector2)mQueue.Dequeue();
			for (int i = 0; i < mDirs.Length; i++ ) {
				if (IsValidMove (top, mDirs[i])) {
					Vector2 newPos = top + mDirs[i];
					if (d[(int)newPos.x][(int)newPos.y] == 0) {
						d[(int)newPos.x][(int)newPos.y] = d[(int)top.x][(int)top.y] + 1;
						mQueue.Enqueue (newPos);
						if (newPos == fin) {
							mQueue.Clear ();
							return d[(int)newPos.x][(int)newPos.y];
						}
					}
				}
			}
		}
		return INF;
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
