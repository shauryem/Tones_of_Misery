using UnityEngine;
using System.Collections;

public class pickupPoints : MonoBehaviour {

	public int scoreToGive;
	private ScoreManager theScoreManager;
	public AudioSource coinSound;
	
	// Called at the start of each game
	
	void Start () {
		
		// Find and sets Score Manager object
		
		theScoreManager = FindObjectOfType<ScoreManager> ();

	}
	
	// If a player collides with a coin, then the score is increased by a set value
	
	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.gameObject.name == "Player")
			{

				theScoreManager.AddScore(scoreToGive);
			gameObject.SetActive(false);
			coinSound.Play ();
			
		}

	}
}
