using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

	public int startingHealth = 100;									//States starting health
	public int currentHealth;  											// states current health
	public Slider healthSlider; 										//Reference to UI Slider
	public Image healthFill;
	public Image damageImage;  											//Flash to show Damage
	public float flashSpeed = 5f;
	public Color flashColor = new Color(1f, 0f, 0f, 0.5f);
	public Animator character;
	public int endTime = 3;


	public Walking walking;

	public AudioSource dmgSound;
	public AudioClip hitSound;


	bool isDead;
	bool damaged;														// True when Damaged

	void Start()
	{
		dmgSound = this.GetComponent<AudioSource> ();
	}
				
	void Awake () {
		currentHealth = startingHealth;
	}

	void Update () {
		if(damaged) {
			damageImage.color = flashColor;
		}
		else {
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}
		damaged = false; 
	}

	public void TakeDamage (int amount) 
	{
		dmgSound.clip = hitSound;
		dmgSound.Play ();
		damaged = true;
		currentHealth -= amount;
		healthSlider.value = currentHealth;
		HealthColor();
		if(currentHealth <=0 && !isDead)
		{
			Dead ();
		}

	}

	void HealthColor () 
	{
		if(currentHealth > 50)
		{
			healthFill.color = new Color (0f, 1f, 0f, 1f);
		}

		else if (50 > currentHealth && currentHealth > 25)
		{
			healthFill.color = new Color (1f, 1f, 0f, 1f);
		}

		else if (currentHealth < 25)
		{
			healthFill.color = new Color (1f, 0f, 0f, 1f);
		}

	}

	public void Dead ()
	{
		if (currentHealth <= 0)
		{
			isDead = true;
			walking.enabled = false;
			character.SetBool ("isDead", true);
			character.SetBool ("Move", false);
			character.SetBool ("Jump", false);
			character.SetBool ("Atk", false);
			StartCoroutine (EndGame());
//			SceneManager.LoadScene ("Menu");
		}
	}

	IEnumerator EndGame ()
	{
		yield return new WaitForSecondsRealtime (endTime);
		SceneManager.LoadScene ("Menu");
	}

}