using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeController : MonoBehaviour {

	private Text TimeText;
	public float timeLeft;

	// Use this for initialization
	void Start () {
		TimeText = GetComponent<Text> ();
		TimeText.text = ""+timeLeft;
	}
	
	// Calculates and reformats time on countdown
	void Update () {
		timeLeft -= Time.deltaTime;
		string timeText = "" + timeLeft;
		int decimalPoint = timeText.IndexOf (".");
		TimeText.text = timeText.Substring (0, decimalPoint);

		if (timeLeft <= 0) {
			SceneManager.LoadScene (6);
		}
	}
}
