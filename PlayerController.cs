using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	private float moveSpeedStore;
	private float speedMileStoneCountStore;
	public float speedMultiplier;
	public float speedIncreaseMilestone;
	private float speedMilestoneCount;
	public float speedIncreaseMilestoneStore;
	public float jumpForce;
	private bool stoppedJumping;
	public float jumpTime;
	private float jumpTimeCounter;
	private Rigidbody2D myRigidbody;
	public AudioSource jumpSound;
	public AudioSource deathSound;
	public bool grounded;
	public LayerMask whatIsGround;
	public Transform groundCheck;
	public float groundCheckRadius;
	private Animator myAnimator;
	public GameManager theGameManager;

	// Called at the start of each game
	
	void Start () {
		// Initializing player variables
		
		myRigidbody = GetComponent<Rigidbody2D>();
		myAnimator = GetComponent<Animator> ();
		jumpTimeCounter = jumpTime;
		speedMilestoneCount = speedIncreaseMilestone;
		moveSpeedStore = moveSpeed;
		speedMileStoneCountStore = speedMilestoneCount;
		speedIncreaseMilestoneStore = speedIncreaseMilestone;
		stoppedJumping = true;
	}
	
	// Update is called once per frame
	void Update () {

		// Checks if the player is on the ground
		
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);
		
		// Increases player speed based on distance traveled
		
		if (transform.position.x > speedMilestoneCount) {
		
			speedMilestoneCount += speedIncreaseMilestone;
			speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;
			moveSpeed = moveSpeed * speedMultiplier;
		}

		myRigidbody.velocity = new Vector2 (moveSpeed, myRigidbody.velocity.y);
		
		// Jump if space bar is pressed OR if clicked on mobile
		
		if(Input.GetKeyDown (KeyCode.Space)|| Input.GetMouseButtonDown(0))
		{
			// only can jump if player is on the ground
			
			if (grounded) 
			{
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jumpForce);
				stoppedJumping = false;
				jumpSound.Play();

			}
		}
		
		// Jumps higher depending on how long button is pressed
		
		if ((Input.GetKey (KeyCode.Space) || Input.GetMouseButton (0)) && !stoppedJumping){
		
			if (jumpTimeCounter > 0) {
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jumpForce);

				jumpTimeCounter -= Time.deltaTime;
			}
		}

		if (Input.GetKeyUp (KeyCode.Space) || Input.GetMouseButtonUp (0)) {
		
			jumpTimeCounter = 0;
			stoppedJumping = true;
		}

		if (grounded) {
		
			jumpTimeCounter = jumpTime;
		
		}
		myAnimator.SetFloat ("Speed", myRigidbody.velocity.x);
		myAnimator.SetBool ("Grounded", grounded);
	}
	
	// Kills player and restarts game if they hit spike
	
	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.tag == "killbox") {
		

			theGameManager.RestartGame ();
			moveSpeed = moveSpeedStore;
			speedMilestoneCount = speedMileStoneCountStore;
			speedIncreaseMilestone = speedIncreaseMilestoneStore;
			deathSound.Play ();
		}
	
	}
}
