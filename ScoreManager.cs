using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text scoreText;
	public Text hiScoreText;
	public float scoreCount;
	public float hiScoreCount;
	public float pointsPerSecond;
	public bool scoreIncreasing;


	// Called at the start of the game
	
	void Start () {
		// Displays high score of player 
		
		if (PlayerPrefs.HasKey ("HighScore")) {
		
			hiScoreCount = PlayerPrefs.GetFloat("HighScore");
		}


	}
	
	// Update is called once per frame
	void Update () {
	
		// Calculate currents score
		
		if (scoreIncreasing){
			scoreCount += pointsPerSecond * Time.deltaTime;
		}
		
		// If current score is higher than high score, update high score
		
		if (scoreCount > hiScoreCount)
		{
			hiScoreCount = scoreCount;
			PlayerPrefs.SetFloat("HighScore", hiScoreCount);
		}
		scoreText.text = "Score: " + Mathf.Round (scoreCount);
		hiScoreText.text = "High Score: " + Mathf.Round (hiScoreCount);

	}
	
	// Helper function to add score to current 
	
	public void AddScore (int pointsToAdd)
	{

		scoreCount += pointsToAdd;

	}
}
