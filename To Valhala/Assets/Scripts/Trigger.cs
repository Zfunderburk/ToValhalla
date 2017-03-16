using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour {

	void OnTriggerEnter (Collider other) {
		if(transform.parent && transform.parent.gameObject != other.gameObject) {
			Debug.Log (transform.parent.gameObject.name + ": I can See" + other.gameObject.name);
		}
	}
}
