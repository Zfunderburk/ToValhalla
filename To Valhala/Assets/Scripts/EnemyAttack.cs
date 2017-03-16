using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour 
{
	public float timeBetweenAttacks = 0.5f;
	public int attackDamage = 10;

	public LayerMask enemyMask;
	float timer;

	public GameObject character;

	public float maxRange;
	public float minRange;

	private Vector2 TargetTrans;

	//Transform target;

	public int moveSpeed;


	Rigidbody2D myBody;	
	Transform myTrans;
	GameObject player;
	PlayerHealth playerHealth;
//	EnemyHealth enemyHealth;


	bool playerInRange = false;

	void Awake () {
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent <PlayerHealth> ();
	}

	void Start () 
	{
		myBody = this.GetComponent <Rigidbody2D> ();		 
		myTrans = this.GetComponent <Transform> ();	
		TargetTrans = character.transform.position;

	}

	/*void OnTriggerEnter (Collider other)
	{
		// if entering collider is the player
		if(other.gameObject == player) 
		{
			playerInRange = true;
		}
	}

	void OnTriggerExit (Collider other)
	{
		// if exiting collider is the player
		if(other.gameObject == player) {
			playerInRange = false;
		}
	}*/

	void Update ()
	{

		//target = GameObject.FindGameObjectWithTag ("Player").transform;

		if ((Vector2.Distance(transform.position, character.transform.position) < maxRange) && (Vector2.Distance(transform.position, character.transform.position) > minRange))
		{
			transform.LookAt (character.transform);
			transform.position += transform.forward * moveSpeed * Time.deltaTime;
		}
		/*if (playerInRange == true)
		{
			Debug.Log("is in range");
			//myTrans.position += myTrans * moveSpeed * Time.deltaTime;
		}*/



		timer += Time.deltaTime;

		if(timer >= timeBetweenAttacks && playerInRange ) {
			Attack ();
		}


	}

	void Attack () {
		timer = 0f;

		if(playerHealth.currentHealth > 0) {
			playerHealth.TakeDamage (attackDamage);
		}
	}
}
