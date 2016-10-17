using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	private Rigidbody rb;
	private Collider collider;
	public float speed;
	[HideInInspector] public bool Jump = false;

	public float MoveForce = 365f;
	public float MaxSpeed = 5f;
	public float JumpForce = 300f;

	private float distToGround;

	void Start(){
		rb = GetComponent<Rigidbody> ();
		collider = GetComponent<Collider> ();
		Debug.Log (collider);
		distToGround = collider.bounds.extents.y;
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.Space) && IsGrounded()) {
			Jump = true;
		}
	}


	bool IsGrounded(){
		return Physics.Raycast (transform.position, -Vector3.up, distToGround + 0.1f);
	}


	void FixedUpdate(){
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

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Pickup")) {
			other.gameObject.SetActive (false);
		} else if (other.gameObject.CompareTag ("Portal")) {
			Debug.Log ("NEXT LEVEL");
		}
	}
}
