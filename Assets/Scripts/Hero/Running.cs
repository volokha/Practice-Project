using UnityEngine;
using System.Collections;

public class Running : MonoBehaviour {

	Rigidbody2D rb;

	public float speed = 5f;

	public float jumpForce;
	public float maxJumpVelocity = 20f;

	public Transform groundChecker; 
	public LayerMask groundLayer;

	public AudioClip runningClip;

	private int currentJumpCount;
	public int maxJumpCount;
	public int countOfJumps {
		
		set {
			currentJumpCount = value;

			//Checking bounds of our jumping count
			if (value > maxJumpCount)
				currentJumpCount = maxJumpCount;
			if (value <= 0)
				currentJumpCount = 0;
		}

		get {
			return currentJumpCount;
		}

	}


	void Start () {
		rb = GetComponent<Rigidbody2D> ();

		SoundManager.Instance.MusicVolume = 0.2f;
		SoundManager.Instance.PlayLoop (runningClip);
	}

	void Update () {
		
		//Checking maxY velocity
		if (rb.velocity.y > maxJumpVelocity)
			rb.velocity = new Vector2(rb.velocity.x, maxJumpVelocity);

		//Giving count of jumps after landing
		if (CheckingGround ())
			countOfJumps = maxJumpCount;

		
		//Moving right
		rb.velocity = new Vector2 (speed, rb.velocity.y);

		//Jumping
		if (Input.GetKeyDown (KeyCode.Space) && countOfJumps != 0) {
			rb.AddForce (new Vector2 (0, jumpForce));
			countOfJumps--;
		}
			
	}

	bool CheckingGround() {
		return Physics2D.OverlapCircle(groundChecker.position, 0.05f, groundLayer);
	}
}
