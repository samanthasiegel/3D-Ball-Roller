using UnityEngine;
using System.Collections;

public class PortalController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Player")) {
			GameObject[] collectibles = GameObject.FindGameObjectsWithTag ("Pickup");
			if (collectibles.Length == 0) {
				Debug.Log ("GO TO LEVEL HERE");
			} else {
				Debug.Log ("NOT YET");
			}
		}
	}
}
