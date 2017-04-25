using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour 
{
	public float timeBetweenAttacks = 0.5f;
	public int attackDamage = 10;

	public Animator character;
/*	public float maxRange;
	public float minRange;*/
	public float attMaxRange;
	public float attMinRange;
	 
	public AudioSource audioAtt;
	public AudioClip axeSound;

	bool enemyRange;
	bool enemyAttRange;

	float timer;

	PlayerHealth playerHealth;
	public EnemyHealth enemyHealth;

	void Start()
	{
		audioAtt = GetComponent<AudioSource> ();
	}

	void Update ()
	{
//		timer += Time.deltaTime;
//
//		if(timer >= timeBetweenAttacks) 
//		{
//			Attack ();
//		}

		timer += Time.deltaTime;

		if(Input.GetButtonDown("Fire1") && enemyHealth != null && timer >= timeBetweenAttacks) 
		{
			Attack ();
		}
	}

	void Attack () 
	{
		audioAtt.clip = axeSound;
		audioAtt.Play ();
		timer = 0f;
		Debug.Log ("called attack");

			character.SetTrigger ("AtkTrig");

			if(enemyHealth.currentHealth > 0) 
			{
				enemyHealth.TakeDamage (attackDamage);
			}
	}
}
