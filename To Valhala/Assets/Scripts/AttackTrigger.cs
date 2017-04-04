using UnityEngine;
using System.Collections;

public class AttackTrigger : MonoBehaviour
{
	public void OnTriggerEnter2D (Collider2D collider)
	{
		if (collider.gameObject.CompareTag ("Player"))
		{
			collider.gameObject.GetComponent <PlayerAttack>().enemyHealth = transform.parent.GetComponent<EnemyHealth>();
		}
	}

	public void OnTriggerExit2D (Collider2D collider)
	{
		if (collider.gameObject.CompareTag ("Player"))
		{
			collider.gameObject.GetComponent <PlayerAttack> ().enemyHealth = null;
		}
	}

}
