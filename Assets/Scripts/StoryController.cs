using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoryController : MonoBehaviour {

	public Button NextButton; 
	public Button GoButton;

	public GameObject StoryText1, StoryText2;

	// Use this for initialization
	void Start () {
		NextButton = NextButton.GetComponent<Button> ();
		GoButton = GoButton.GetComponent<Button> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void NextClicked(){
		StoryText1.gameObject.SetActive (false);
		StoryText2.gameObject.SetActive (true);
	}

	public void GoClicked(){
		SceneManager.LoadScene (2);
	}
}
