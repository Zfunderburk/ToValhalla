using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour 
{
	public float timeBetweenAttacks = 0.5f;
	public int attackDamage = 10;


	float timer;


	PlayerHealth playerHealth;
	EnemyHealth enemyHealth;


	void Update ()
	{
		timer += Time.deltaTime;

		if(timer >= timeBetweenAttacks) 
		{
			Attack ();
		}
	}

	void Attack () {
		timer = 0f;
		//needs a on mouse button click type thing
		if(playerHealth.currentHealth > 0) {
			playerHealth.TakeDamage (attackDamage);
		}
	}
}
