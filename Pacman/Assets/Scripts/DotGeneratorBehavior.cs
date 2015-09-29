using UnityEngine;
using System.Collections;

public class DotGeneratorBehavior : MonoBehaviour {

	public GameObject DotObject;
	public LayerMask WhatIsWall;
	private float mRadius = 0.05f;

	void Start () {
		for ( int i = 2; i < 28; i++ ) 
			for ( int j = 2; j < 34; j++ ) {
				Vector2 pos = new Vector2(i,j);
				if ( isValidPosition(pos) ) 	
					Instantiate( DotObject, pos, Quaternion.identity );
			}
					
	}

	private bool isValidPosition( Vector2 pos ) {
		DotObject.GetComponent <BoxCollider2D>().enabled = false;
		bool isValid = (Physics2D.OverlapCircle(pos, mRadius, WhatIsWall) == null);
		DotObject.GetComponent <BoxCollider2D>().enabled = true;
		return isValid;
	}

	void Update () {
		
	}
}
