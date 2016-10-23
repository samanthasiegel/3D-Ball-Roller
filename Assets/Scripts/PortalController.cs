using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PortalController : MonoBehaviour {

	public int nextLevel;
	public AudioClip VictoryClip;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Move onto next level if all pickups have been collected
	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Player")) {
			GameObject[] collectibles = GameObject.FindGameObjectsWithTag ("Pickup");
			//If all pickups collected, move onto next level
			if (collectibles.Length == 0) {
				StartCoroutine (WaitForLevel ());
			} 
		}
	}

	// Starts next level scene
	IEnumerator WaitForLevel(){
		AudioSource.PlayClipAtPoint (VictoryClip, transform.position);
		yield return new WaitForSeconds (1f);
		SceneManager.LoadScene (nextLevel);
	}
}
