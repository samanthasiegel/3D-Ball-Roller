using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndSceneController : MonoBehaviour {

	public Button PlayAgainButton;
	public Button QuitButton;

	public AudioClip VictoryMusic;

	void Start () {
		PlayAgainButton = PlayAgainButton.GetComponent<Button> ();
		QuitButton = QuitButton.GetComponent<Button> ();
		AudioSource.PlayClipAtPoint (VictoryMusic, transform.position);
	
	}
		
		
	public void PlayAgainClicked(){
		SceneManager.LoadScene (0);
	}

	public void QuitClicked(){
		Application.Quit ();
	}


}
