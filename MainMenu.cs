using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public string playGameLevel;

	// Loads Game Scene
	public void PlayGame ()
	{
		Application.LoadLevel (playGameLevel);
	}

	// Quits Whole Application
	
	public void QuitGame()
	{
	
		Application.Quit ();
	
	
	}
}
