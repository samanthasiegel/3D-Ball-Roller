using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

	// Rotates object to increase visibility
	void Update () {
		transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
	
	}


}
