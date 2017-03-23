using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour 
{
	public int startingHealth = 100;
	public int currentHealth;
	public AudioClip deathClip;

	Animator anim;
	AudioSource enemyAudio;
	CapsuleCollider capsuleCollider;
	bool isDead;

	public GameObject enemy;


	void Awake ()
	{
		anim = GetComponent <Animator> ();
		enemyAudio = GetComponent <AudioSource> ();
		capsuleCollider = GetComponent <CapsuleCollider> ();

		currentHealth = startingHealth; // sets the current health to 100 so it is the same as the starting health
	}


	public void TakeDamage (int amount)
	{
		if (isDead)
		{
			return;			//if the enemy is dead there is no point in calculating damage
		}

		enemyAudio.Play ();		//plays the audio when the enemy is hit

		currentHealth -= amount;


		if(currentHealth <= 0)
		{
			Death ();
		}

	}


	void Death ()
	{
		isDead = true;

		capsuleCollider.isTrigger = true;

		anim.SetTrigger ("Dead"); 	//this "Dead" could change depending on what the animations are called make sure they match

		enemyAudio.clip = deathClip;
		enemyAudio.Play ();

		GameObject.Destroy (enemy);
	}

}
