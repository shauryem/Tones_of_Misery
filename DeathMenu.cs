using UnityEngine;
using System.Collections;

public class DeathMenu : MonoBehaviour {

	public string mainMenuLevel;
	
	// Restarts game and score
	public void RestartGame()
	{
		FindObjectOfType<GameManager> ().Reset ();

	}
	// Quits to main menu
	public void QuitToMain ()
	{
		Application.LoadLevel (mainMenuLevel);
	}
}
