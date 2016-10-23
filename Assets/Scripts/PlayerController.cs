using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	private Rigidbody rb;
	private Collider collider;
	public float speed;
	[HideInInspector] public bool Jump = false;

	// Movement mechanics global variables 
	public float MoveForce = 365f;
	public float MaxSpeed = 5f;
	public float JumpForce = 300f;

	// Ground check global variables
	private float distToGround;
	private bool Grounded = false;

	// Variables for disabling player movement after contact with water
	private bool Alive = true;
	private bool WaterEffect = false;

	// Audio clips for sound effects
	public AudioClip WaterClip;
	public AudioClip SeasonClip;


	void Start(){
		InitGroundCheck ();
		AudioSource.PlayClipAtPoint (SeasonClip, transform.position);
	}

	// Checks for contact with ground
	public void InitGroundCheck(){
		collider = GetComponent<Collider> ();
		distToGround = collider.bounds.extents.y;
		rb = GetComponent<Rigidbody> ();

	}

	void Update(){
		Grounded = Physics.Raycast (transform.position, -Vector3.up, distToGround + 0.1f);
		if (Input.GetKeyDown (KeyCode.Space) && Grounded) {
			Jump = true;
		}
	}




	void FixedUpdate(){
		// If we're enabled to jump and/or move the player
		if (Alive) {
			if (Jump) { 
				rb.AddForce (Vector3.up * JumpForce);
				Jump = false;
			} else {
				float moveHorizontal = Input.GetAxis ("Horizontal");
				float moveVertical = Input.GetAxis ("Vertical");
				Vector3 movement = new Vector3 (moveHorizontal, 0, moveVertical);
				if (moveHorizontal * rb.velocity.x < MaxSpeed && moveVertical * rb.velocity.y < MaxSpeed) {
					rb.AddForce (movement * speed);
				}
			}
		}

	}

	void OnTriggerEnter(Collider other){
		// Deactivate pickup object
		if (other.gameObject.CompareTag ("Pickup")) {
			other.gameObject.SetActive (false);
		} 
		// Move onto next level
		else if (other.gameObject.CompareTag ("Portal")) {
			Debug.Log ("NEXT LEVEL");
		}
	}

	void OnTriggerStay(Collider other){
		// Temporarily disable player
		if (other.gameObject.CompareTag ("Water") && !WaterEffect) {
			Alive = false;
			AudioSource.PlayClipAtPoint (WaterClip, transform.position);
			StartCoroutine (Disable ());
		}
	}

	/* Disables player movement temporarily after contact with water */
	IEnumerator Disable(){
		// Playser starts feeling the effect of the water
		WaterEffect = true;
		int numTimes = 6;
		MeshRenderer mr = GetComponent<MeshRenderer> ();

		//Disable player movement for 2 seconds
		yield return new WaitForSeconds (2f);

		while (numTimes > 0) {

			//Re-enable player movement
			Alive = true;

			// Flicker player renderer on and off
			mr.enabled = false;
			yield return new WaitForSeconds (0.2f);
			mr.enabled = true;
			yield return new WaitForSeconds (0.2f);

			numTimes--;
		}

		yield return new WaitForSeconds (1f);

		// Player no longer feels the effect of the water
		WaterEffect = false;
	}
}
