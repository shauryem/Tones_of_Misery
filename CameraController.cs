using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public PlayerController thePlayer;
	private Vector3 lastPlayerPosition;
	private float distanceToMove;


	// called at the start of each game
	void Start () {
		thePlayer = FindObjectOfType <PlayerController> ();
		lastPlayerPosition = thePlayer.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
		// updates the camera to move with the player
		
		distanceToMove = thePlayer.transform.position.x - lastPlayerPosition.x;
		transform.position = new Vector3 (transform.position.x + distanceToMove, transform.position.y, transform.position.z);
		lastPlayerPosition = thePlayer.transform.position;
	}
}
