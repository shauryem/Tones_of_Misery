using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {


	public Transform platformGenerator;
	private Vector3 platformStartPoint;
	public PlayerController thePlayer;
	private Vector3 playerStartPoint;
	private PlatformDestroyer[] platformList;
	private ScoreManager theScoreManager;
	public DeathMenu theDeathScreen;

	// Called at the start of the game
	void Start () {
	
		platformStartPoint = platformGenerator.position;
		playerStartPoint = thePlayer.transform.position;
		theScoreManager = FindObjectOfType<ScoreManager> ();

	}
	
	// Resets initial game variables such as score
	public void RestartGame()
	{
	
		theScoreManager.scoreIncreasing = false;
		thePlayer.gameObject.SetActive (false);
		theDeathScreen.gameObject.SetActive (true);


	}

	public void Reset()
	{
		theDeathScreen.gameObject.SetActive (false);
		platformList = FindObjectsOfType<PlatformDestroyer> ();
		
		// Delete all current platforms
		
		for (int i = 0; i < platformList.Length; i++) {

			platformList [i].gameObject.SetActive (false);
		}
		// reinitialize variables to starting positions
		
		thePlayer.transform.position = playerStartPoint;
		platformGenerator.position = platformStartPoint;
		thePlayer.gameObject.SetActive (true);

		theScoreManager.scoreCount = 0;
		theScoreManager.scoreIncreasing = true;
	}
}
