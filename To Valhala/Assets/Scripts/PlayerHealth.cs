﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

	public int startingHealth = 100;									//States starting health
	public int currentHealth;  											// states current health
	public Slider healthSlider; 										//Reference to UI Slider
	public Image damageImage;  											//Flash to show Damage
	public float flashSpeed = 5f;
	public Color flashColor = new Color(1f, 0f, 0f, 0.1f);
	public Animator character;

	public Walking walking;

	bool isDead;
	bool damaged;														// True when Damaged
				
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

	public void TakeDamage (int amount) {
		damaged = true;
		currentHealth -= amount;
		healthSlider.value = currentHealth;
		if(currentHealth <=0 && !isDead)
		{
			Dead ();
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
			SceneManager.LoadScene ("Menu");
		}
	}

}