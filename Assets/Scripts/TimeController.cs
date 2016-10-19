using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeController : MonoBehaviour {

	private Text TimeText;
	public float timeLeft;
	// Use this for initialization
	void Start () {
		TimeText = GetComponent<Text> ();
		TimeText.text = ""+timeLeft;
	}
	
	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;
		string timeText = "" + timeLeft;
		int decimalPoint = timeText.IndexOf (".");
		TimeText.text = timeText.Substring (0, decimalPoint);
	}
}
