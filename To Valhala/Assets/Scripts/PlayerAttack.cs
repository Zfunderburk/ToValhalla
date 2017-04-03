using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour 
{
	public float timeBetweenAttacks = 0.5f;
	public int attackDamage = 10;

	public Animator character;
	public float maxRange;
	public float minRange;
	public float attMaxRange;
	public float attMinRange;

	bool enemyRange;
	bool enemyAttRange;

	float timer;


	PlayerHealth playerHealth;
	EnemyHealth enemyHealth;


	void Update ()
	{
//		timer += Time.deltaTime;
//
//		if(timer >= timeBetweenAttacks) 
//		{
//			Attack ();
//		}

		if ((Vector2.Distance(transform.position, character.transform.position) < attMaxRange) && (Vector2.Distance(transform.position, character.transform.position) > attMinRange))
		{

			enemyAttRange = true;
		}

		timer += Time.deltaTime;

		if(timer >= timeBetweenAttacks && enemyAttRange ) 
		{
			Attack ();
		}
		enemyAttRange = false;
	}

	void Attack () {
		timer = 0f;
		if (Input.GetButtonDown("Fire1"))
		{
			character.SetBool ("Atk", true);
		}
		if(enemyHealth.currentHealth > 0) {
			enemyHealth.TakeDamage (attackDamage);
		}
	}
}
