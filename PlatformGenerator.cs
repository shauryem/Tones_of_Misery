using UnityEngine;
using System.Collections;

public class PlatformGenerator : MonoBehaviour {

	public GameObject  thePlatform;
	public Transform generationPoint;
	public float distanceBetween;
	private float platformWidth;
	public float distanceBetweenMin;
	public float distanceBetweenMax;
	public GameObject[] thePlatforms;
	private int platformSelector;
	private float[] platformWidths;
	private float minHeight;
	public Transform maxHeightPoint;
	private float maxHeight;
	public float maxHeightChange;
	private float heightChange;

	// Called at the start of the game
	void Start () {
		// Sets platform size
		
		platformWidths = new float[thePlatforms.Length];
		for (int i = 0; i < thePlatforms.Length; i++) {
			platformWidths[i] = thePlatforms[i].GetComponent < BoxCollider2D> ().size.x;
		}
		// Although platforms are given random heights, we still need a min and max to make every jump possible
		
		minHeight = transform.position.y;
		maxHeight = maxHeightPoint.position.y;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (transform.position.x < generationPoint.position.x)
		{
			// Creates a platform with random height and distance between next platform
			
			distanceBetween = Random.Range (distanceBetweenMin, distanceBetweenMax);
			platformSelector = Random.Range (0, thePlatforms.Length);
			heightChange = transform.position.y + Random.Range (maxHeightChange, -maxHeightChange);
			
			// Make sure all jumps are possible 
			
			if (heightChange > maxHeight) {
				heightChange = maxHeight;
			} else if (heightChange < minHeight) {
				heightChange = minHeight;
			}
			
			transform.position = new Vector3 (transform.position.x + platformWidths[platformSelector] + distanceBetween, heightChange, transform.position.z);
			Instantiate (/*thePlatform*/ thePlatforms[platformSelector] , transform.position, transform.rotation);

		}
	}
}
