using UnityEngine;
using System.Collections;

public class BallSizeController : MonoBehaviour {


	private int SizeTrackerInt;
	// this int is used to track the size of the ball... when SizeTracker = 0, the ball is small,
	// when SizeTracker = 1, the ball is medium size, and when SizeTracker = 2, the ball is large.

	private bool SizeTrackerBool;

	private Vector3 OriginalSize;

	void Start(){

		SizeTrackerInt = 1;
		SizeTrackerBool = true;
		OriginalSize = transform.localScale;
	}

	// Update is called once per frame
	void Update () {
		
		if(Input.GetKeyDown(KeyCode.S)){

			ChangeSize ();

		}
	}

	void ChangeSize(){

		if (SizeTrackerInt == 1) {

			if (SizeTrackerBool) {

				SizeTrackerBool = !SizeTrackerBool;
				SizeTrackerInt = 2;
				transform.localScale = new Vector3 (OriginalSize.x * 2f, OriginalSize.y * 2f, OriginalSize.z * 2f);
				
			} else {

				SizeTrackerInt = 0;
				SizeTrackerBool = !SizeTrackerBool;
				transform.localScale = new Vector3 (OriginalSize.x * 0.5f, OriginalSize.y * 0.5f, OriginalSize.z * 0.5f);
			}
		}

		else if (SizeTrackerInt == 2) {

			SizeTrackerInt = 1;
			transform.localScale = OriginalSize;
		}

		else {

			SizeTrackerInt = 1;
			transform.localScale = new Vector3 (OriginalSize.x, OriginalSize.y, OriginalSize.z);
		}
	}
}