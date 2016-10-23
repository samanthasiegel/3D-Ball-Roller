using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoseScreenScript : MonoBehaviour
{
	public void QuitGame(){

		Application.Quit ();
	}

	public void MainMenu(){

		SceneManager.LoadScene (0);
	}
}

