using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public GameObject player;
	public GameObject boundsLeft;
	public GameObject boundsRight;
	public float yOffset = 1;


	void Update ()
	{
		float camX = transform.position.x;
		Vector3 campos = transform.position;
		if(camX < boundsRight.transform.position.x && camX > boundsLeft.transform.position.x)
		{
			campos.x = player.transform.position.x;
		}
		campos.y = player.transform.position.y + yOffset;
		transform.position = campos;
	}



}
