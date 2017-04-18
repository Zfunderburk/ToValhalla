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

//	Animator anim;
//	AudioSource enemyAudio;
//	BoxCollider2D boxCollider;
	bool isDead;
	bool damaged;



	void Awake ()
	{
//		anim = GetComponent <Animator> ();
//		enemyAudio = GetComponent <AudioSource> ();
//		boxCollider = GetComponent <BoxCollider2D> ();

		currentHealth = startingHealth; // sets the current health to 100 so it is the same as the starting health
	}


	void Update () 
	{
		
	}



	public void TakeDamage (int amount)
	{
		Debug.Log ("taking dmg");
		damaged = true;
		currentHealth -= amount;
//		enemyHealth.value = currentHealth;
		if (currentHealth <= 0 && !isDead)
		{
			Death ();
		}
	}


	void Death ()
	{
		/*isDead = true;
		zombie.SetBool ("isDead", true);
	

		//boxCollider.isTrigger = true;

		anim.SetTrigger ("Dead"); 	//this "Dead" could change depending on what the animations are called make sure they match

//		enemyAudio.clip = deathClip;
		enemyAudio.Play ();*/
		FindObjectOfType<GameManager> ().enemiesKilled++;
		GameObject.Destroy (this.gameObject);
	}

}
