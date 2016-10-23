using UnityEngine;
using System.Collections;

public class BallSizeController : MonoBehaviour {


	private int SizeTrackerInt;
	// this int is used to track the size of the ball
	// 0 = ball is small, next state is normal
	// 1 = ball is normal, next state is big
	// 2 = ball is big, next state is normal
	// 3 = ball is normal, next state is small

	private bool SizeTrackerBool;

	private Vector3 OriginalSize;

	void Start(){

		SizeTrackerInt = 1;
		SizeTrackerBool = true;
		OriginalSize = transform.localScale;
	}

	// Change size of player if hit key "s"
	void Update () {
		
		if(Input.GetKeyDown(KeyCode.S)){
			ChangeSize ();

		}
	}

	// Changes size of snowball to next state, and updates jump force accordingly
	void ChangeSize(){
		if (SizeTrackerInt == 0) {
			SizeTrackerInt = 1;
			transform.localScale = new Vector3 (OriginalSize.x, OriginalSize.y, OriginalSize.z);
			GetComponent<PlayerController> ().JumpForce = 250f;
		} else if (SizeTrackerInt == 1) {
			SizeTrackerInt = 2;
			transform.localScale = new Vector3 (OriginalSize.x * 2f, OriginalSize.y * 2f, OriginalSize.z * 2f);
			GetComponent<PlayerController> ().JumpForce = 300f;
		} else if (SizeTrackerInt == 2) {
			SizeTrackerBool = !SizeTrackerBool;
			SizeTrackerInt = 3;
			transform.localScale = new Vector3 (OriginalSize.x, OriginalSize.y, OriginalSize.z);
			GetComponent<PlayerController> ().JumpForce = 250f;
		} else if(SizeTrackerInt == 3){
			SizeTrackerInt = 0;
			transform.localScale = new Vector3 (OriginalSize.x * 0.5f, OriginalSize.y * 0.5f, OriginalSize.z * 0.5f);
			GetComponent<PlayerController> ().JumpForce = 200f;
		}

		GetComponent<PlayerController> ().InitGroundCheck ();
	}
}