using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {

	Transform player;
	PlayerHealth playerHealth;
//	EnemyHealth enemyHealth;
	NavMeshAgent nav;

	void Awake () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		playerHealth = player.GetComponent <PlayerHealth> ();
		nav = GetComponent<NavMeshAgent> ();
	}

	void Update () {
		if(playerHealth.currentHealth > 0) {
			nav.SetDestination (player.position);
		}

		else {
			nav.enabled = false;
		}
	}
}
