using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour 
{
	public int startingHealth = 100;
	public int currentHealth;
//	public AudioClip deathClip;
	public Slider enemyHealth;
	public Animator zombie;
	public int point = 0;

	Animator anim;
	AudioSource enemyAudio;
	BoxCollider2D boxCollider;
	bool isDead;
	bool damaged;



	public GameObject enemy;


	void Awake ()
	{
		anim = GetComponent <Animator> ();
		enemyAudio = GetComponent <AudioSource> ();
		boxCollider = GetComponent <BoxCollider2D> ();

		currentHealth = startingHealth; // sets the current health to 100 so it is the same as the starting health
	}


	void Update () 
	{
		
	}

//	public void TakeDamage (int amount)
//	{
//		if (isDead)
//		{
//			return;			//if the enemy is dead there is no point in calculating damage
//		}
//
//		enemyAudio.Play ();		//plays the audio when the enemy is hit
//
//		currentHealth -= amount;
//
//
//		if(currentHealth <= 0)
//		{
//			Death ();
//		}
//
//	}

	public void TakeDamage (int amount)
	{
		damaged = true;
		currentHealth -= amount;
		enemyHealth.value = currentHealth;
		if (currentHealth <= 0 && !isDead)
		{
			Death ();
		}
		damaged = false;
	}


	void Death ()
	{
		isDead = true;
		zombie.SetBool ("isDead", true);
		point++;

		//boxCollider.isTrigger = true;

		anim.SetTrigger ("Dead"); 	//this "Dead" could change depending on what the animations are called make sure they match

//		enemyAudio.clip = deathClip;
		enemyAudio.Play ();

		GameObject.Destroy (enemy);
	}

}
