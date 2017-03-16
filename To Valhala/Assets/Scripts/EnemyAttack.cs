using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour 
{
	public float timeBetweenAttacks = 0.5f;
	public int attackDamage = 10;
	public int moveSpeed;
	public LayerMask enemyMask;
	float timer;

	Rigidbody2D myBody;	
	Transform myTrans;
	GameObject player;
	PlayerHealth playerHealth;
//	EnemyHealth enemyHealth;


	bool playerInRange;  

	void Awake () {
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent <PlayerHealth> ();
	}

	void Start () 
	{
		myBody = this.GetComponent <Rigidbody2D> ();		 
		myTrans = this.GetComponent <Transform> ();		
	}

	void OnTriggerEnter (Collider other)
	{
		// if entering collider is the player
		if(other.gameObject == player) {
			playerInRange = true;
		}
	}

	void OnTriggerExit (Collider other)
	{
		// if exiting collider is the player
		if(other.gameObject == player) {
			playerInRange = false;
		}
	}

	void Update () {
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
