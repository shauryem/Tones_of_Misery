using UnityEngine;
using System.Collections;

public class PlatformDestroyer : MonoBehaviour {

	public GameObject platformDestructionPoint;


	// Called at the start of each game
	
	void Start () {
		// Sets the point where platforms destruct (when they're off the screen)
		platformDestructionPoint = GameObject.Find ("Platform Destruction Point");

	}
	
	// Update is called once per frame
	void Update () {
		
		// Destructs platform once off screen 
		if (transform.position.x < platformDestructionPoint.transform.position.x) {
			Destroy (gameObject);
		}
	}
}
