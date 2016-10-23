using UnityEngine;
using System.Collections;

public class Bouncer : MonoBehaviour {


	private float yPosition;
	public int direction = 1;

	// Use this for initialization
	void Start () {

		yPosition = transform.position.y;
		StartCoroutine (Bounce ());
	}
	
	// Update is called once per frame
	void Update () {

	
	}


	IEnumerator Bounce(){
		while (gameObject.activeSelf) {
			if (transform.position.y > (yPosition + 0.2f)) {
				direction = -1;
			} else if(transform.position.y < (yPosition - 0.2f)){
				direction = 1;
			}
			Vector3 movement = Vector3.down * direction * 0.02f;
			transform.Translate (movement);
			yield return new WaitForSeconds (0.02f);
		}
	}

}
