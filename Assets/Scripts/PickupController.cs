using UnityEngine;
using System.Collections;

public class PickupController : MonoBehaviour {


	public AudioClip PickupClip;

	// Plays pickup sound when player collides with object
	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Player")) {
			AudioSource.PlayClipAtPoint (PickupClip, transform.position);
		}
	}
}
