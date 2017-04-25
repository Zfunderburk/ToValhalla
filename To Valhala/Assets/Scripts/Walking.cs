using UnityEngine;
using System.Collections;


public class Walking : MonoBehaviour 
{
	public float maxSpeed = 10f;				//walking speed
	public float jumpVelocity = 7f;				//jump height	
	public LayerMask playerMask;				//sets the layermask so that the raycast from the player hits the ground and turns isgrounded to true and false
	public Animator character;

	Transform myTrans;							//sets a transform to the transform of the object the script is attachted to
	public Transform tagGround;						// transform of the tag on the capsul 

	Rigidbody2D myBody;							//sets a rigidbody to the rigidbody of the object

	public bool canMoveInAir = true;
	public bool isGrounded = false;					//will allow for double jumps

	public AudioSource walk;
	public AudioClip walkClip;



	void Start ()
	{
		myBody = this.GetComponent <Rigidbody2D> ();		//calling rigidbody 
		myTrans = this.GetComponent <Transform> ();			//calling transform

		//tagGround = GameObject.Find (this.name + "/ground_Tag").transform; //this calls the character gameobject then calls a child of that game object called ground_Tag
	}




	void FixedUpdate ()
	{
		RaycastHit2D hit = Physics2D.Linecast (myTrans.position, tagGround.position, playerMask);
		//Debug.Log (hit.collider.name);
		isGrounded = hit.collider != null;


		Move (Input.GetAxis ("Horizontal"));

		if (Input.GetButtonDown ("Jump") && isGrounded)
			{
			Jump ();
			character.SetTrigger ("Jump");
			}

		if (Input.GetButtonDown("Fire1"))
		{
			Attack ();
		}
	}

	public void Move (float horizontalInput)
	{
		// If we are getting input let the animator know
		// we are implementing this using a ternary operator
		// https://unity3d.com/learn/tutorials/topics/scripting/ternary-operator
		character.SetBool("Move", horizontalInput != 0 ? true : false);

		walk.clip = walkClip;
		walk.Play ();

		if (!canMoveInAir && !isGrounded)					//if both of these are false the player can not change direction in the air
			return;
		if (horizontalInput < 0)
		{
			transform.localScale = new Vector3 (-0.6f, 0.6f, 1f);

		}
		else
		{
			transform.localScale = new Vector3 (0.6f, 0.6f, 1f);
		}

		Vector2 moveVel = myBody.velocity;					//makes the rigidbody and velocity into a vector2
		moveVel.x = horizontalInput * maxSpeed;				//moveVel is maxspeed multiplied by the input from the keyboard
		myBody.velocity = moveVel;							//sets the velocity on the rigibody to the above statement
	}

	public void Jump ()
	{
		myBody.velocity += jumpVelocity * Vector2.up; 		//vector2.up just sets them both to 0 same as New Vector 2 (0, 0)
	}

	public void Attack ()
	{
		character.SetBool ("Atk", true);
	}
}
