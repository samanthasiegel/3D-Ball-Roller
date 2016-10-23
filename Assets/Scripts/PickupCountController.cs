using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PickupCountController : MonoBehaviour {


	public Text PickupCount;

	// Use this for initialization
	void Start () {
	}
	
	// Keeps track of number of pickups on screen
	void Update () {
		int numberOfPickups = GameObject.FindGameObjectsWithTag ("Pickup").Length;
		PickupCount.text = "Number of pickups: " + numberOfPickups;
	
	}
}
