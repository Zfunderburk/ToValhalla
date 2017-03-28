using UnityEngine;
using System.Collections;


public class Walking : MonoBehaviour 
{
	public float maxSpeed = 10f;				//walking speed
	public float jumpVelocity = 7f;				//jump height	

	public LayerMask playerMask;				//sets the layermask so that the raycast from the player hits the ground and turns isgrounded to true and false

	Transform myTrans;							//sets a transform to the transform of the object the script is attachted to
	Transform tagGround;						// transform of the tag on the capsul 

	Rigidbody2D myBody;							//sets a rigidbody to the rigidbody of the object

	public bool canMoveInAir = true;
	public bool isGrounded = false;					//will allow for double jumps

	void Start ()
	{
		myBody = this.GetComponent <Rigidbody2D> ();		//calling rigidbody 
		myTrans = this.GetComponent <Transform> ();			//calling transform

		tagGround = GameObject.Find (this.name + "/ground_Tag").transform; //this calls the character gameobject then calls a child of that game object called ground_Tag
	}


	void FixedUpdate ()
	{
		isGrounded = Physics2D.Linecast (myTrans.position, tagGround.position, playerMask);


		//Move (Input.GetAxisRaw ("Horizontal"));			//everyone liked the other better but leaving in to maybe use later	
		Move (Input.GetAxis ("Horizontal"));				//adds a speed up to max walking speed instead of immediatly being at that speed like raw
		if (Input.GetButtonDown ("Jump"))
			{
			Jump ();
			}
	}

	public void Move (float horizontalInput)
	{
		if (!canMoveInAir && !isGrounded)					//if both of these are false the player can not change direction in the air
			return;

		Vector2 moveVel = myBody.velocity;					//makes the rigidbody and velocity into a vector2
		moveVel.x = horizontalInput * maxSpeed;				//moveVel is maxspeed multiplied by the input from the keyboard
		myBody.velocity = moveVel;							//sets the velocity on the rigibody to the above statement
	}

	public void Jump ()
	{
		if (isGrounded)
			myBody.velocity += jumpVelocity * Vector2.up; 		//vector2.up just sets them both to 0 same as New Vector 2 (0, 0)
	}
}
