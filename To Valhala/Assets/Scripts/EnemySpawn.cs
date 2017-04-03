using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour 
{
	public PlayerHealth playerHealth;
	public GameObject enemy;
	public Transform[] spawnPoint;


	void Spawn () 
	{
		if(playerHealth.currentHealth <= 0)
		{
			return;
		}

		int spawnPointIndex = Random.Range (0, spawnPoint.Length);

		Instantiate (enemy, spawnPoint[spawnPointIndex].position, spawnPoint[spawnPointIndex].rotation);
	}



}
