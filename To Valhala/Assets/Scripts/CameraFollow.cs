using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public GameObject player;
	public GameObject boundsLeft;
	public GameObject boundsRight;
	public float xOffset = 1;
	public float yOffset = 2;

	public AudioListener listener;

	void Start()
	{
		listener = this.GetComponent<AudioListener> ();
	}


	void Update ()
	{
		float px = player.transform.position.x;

		Vector3 campos = transform.position;

		campos.x = Mathf.Min(Mathf.Max(px, boundsLeft.transform.position.x), boundsRight.transform.position.x) + xOffset;

		campos.y = player.transform.position.y + yOffset;

		transform.position = campos;
	}



}
