using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpawnController : MonoBehaviour {

	public GameObject Pickup;
	public float spawnTime = 6f;
	public int xFloor, xCeil;
	public int zFloor, zCeil;

	public Text PickupCount;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
	}
	
	// Update is called once per frame
	void Update () {
		int numberOfPickups = GameObject.FindGameObjectsWithTag ("Pickup").Length;
		PickupCount.text = "Number of pumpkins: " + numberOfPickups;

	}

	void Spawn(){
		int x = Random.Range(xFloor, xCeil);
		int z = Random.Range (zFloor, zCeil);
		Vector3 v3 = new Vector3 (x, 0.65f, z);
		Instantiate (Pickup, v3, transform.rotation);
	}
}
