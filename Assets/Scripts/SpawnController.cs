using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpawnController : MonoBehaviour {

	// Object that is being spawned
	public GameObject Pickup;

	// Frequency of spawning
	public float spawnTime = 6f;

	// Radius of spawning area
	public float xFloor, xCeil;
	public float zFloor, zCeil;
	public float yFloor, yCeil;

	// Amount of time spawning should be active
	public float stopSpawning;


	// Use this for initialization
	void Start () {
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
	}

	// Update is called once per frame
	void Update () {
		stopSpawning -= Time.deltaTime;

	}

	// Spawn object at random place in radius 
	void Spawn(){
		if (stopSpawning > 0) {
			float x = Random.Range (xFloor, xCeil);
			float y = Random.Range (yFloor, yCeil);
			float z = Random.Range (zFloor, zCeil);
			Vector3 v3 = new Vector3 (x, y, z);
			Instantiate (Pickup, v3, transform.rotation);
		}
	}
}
