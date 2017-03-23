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

	public float attMaxRange;
	public float attMinRange;


	public int moveSpeed;


	Rigidbody2D myBody;	
	Transform myTrans;
	GameObject player;
	PlayerHealth playerHealth;
	EnemyHealth enemyHealth;

	bool playerAttRange;
	bool playerInRange;

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



	void Update ()
	{


		// enemy will move towards the character when in range
		if ((Vector2.Distance(transform.position, character.transform.position) < maxRange) && (Vector2.Distance(transform.position, character.transform.position) > minRange))
		{
			transform.LookAt (character.transform);
			transform.position += transform.forward * moveSpeed * Time.deltaTime;
		
		}
		// enemy will deal damage within a range
		if ((Vector2.Distance(transform.position, character.transform.position) < attMaxRange) && (Vector2.Distance(transform.position, character.transform.position) > attMinRange))
		{
			
			playerAttRange = true;
		}

		timer += Time.deltaTime;

		if(timer >= timeBetweenAttacks && playerAttRange ) 
		{
			Attack ();
		}
		playerAttRange = false;


	}

	void Attack () {
		timer = 0f;

		if(playerHealth.currentHealth > 0) {
			playerHealth.TakeDamage (attackDamage);
		}
	}
}
