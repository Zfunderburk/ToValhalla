using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public GameObject player;
	public GameObject boundsLeft;
	public GameObject boundsRight;
	public float yOffset = 1;


	void Update ()
	{
		float px = player.transform.position.x;

		Vector3 campos = transform.position;

		campos.x = Mathf.Min(Mathf.Max(px, boundsLeft.transform.position.x), boundsRight.transform.position.x);

		campos.y = player.transform.position.y + yOffset;

		transform.position = campos;
	}



}
