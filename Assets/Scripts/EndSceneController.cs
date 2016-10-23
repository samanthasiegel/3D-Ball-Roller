using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndSceneController : MonoBehaviour {

	public Button PlayAgainButton;
	public Button QuitButton;

	public AudioClip VictoryMusic;

	// Use this for initialization
	void Start () {
		PlayAgainButton = PlayAgainButton.GetComponent<Button> ();
		QuitButton = QuitButton.GetComponent<Button> ();
		AudioSource.PlayClipAtPoint (VictoryMusic, transform.position);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PlayAgainClicked(){
		SceneManager.LoadScene (0);
	}

	public void QuitClicked(){
	}


}
