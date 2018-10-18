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

	//private Collider2D myCollider;

	private Animator myAnimator;

	public GameManager theGameManager;

	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D>();

		//myCollider = GetComponent<Collider2D> ();

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

		//grounded = Physics2D.IsTouchingLayers (myCollider, whatIsGround);
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);

		if (transform.position.x > speedMilestoneCount) {
		
			speedMilestoneCount += speedIncreaseMilestone;

			speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;
			moveSpeed = moveSpeed * speedMultiplier;
		}

		myRigidbody.velocity = new Vector2 (moveSpeed, myRigidbody.velocity.y);

		if(Input.GetKeyDown (KeyCode.Space)|| Input.GetMouseButtonDown(0))
		{

			if (grounded) 
			{


				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jumpForce);
				stoppedJumping = false;
				jumpSound.Play();
			
			}
			}
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
