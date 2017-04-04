using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	
	public int enemiesKilled = 0;


	void Update () {
		if(enemiesKilled == 4)
		{
			SceneManager.LoadScene("Menu");
		}
	}
}
