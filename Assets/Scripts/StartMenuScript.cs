using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenuScript : MonoBehaviour {

	public Button StartButton;

	// Use this for initialization
	void Start () {
		StartButton = StartButton.GetComponent<Button> ();

	}

	public void StartClicked(){
		SceneManager.LoadScene (1);
	}
}
