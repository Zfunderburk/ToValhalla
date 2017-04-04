using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	
	public int enemiesKilled = 0;
	public Text winText;
	private bool isGameOver;

	void Update () {
		if(enemiesKilled == 4)
		{
			Color temp = winText.color;
			temp.a = 1f;
			winText.color = temp; 
//			SceneManager.LoadScene("Menu");
			if(!isGameOver){
				isGameOver = true;
				StartCoroutine(LoadSceneinSeconds(3f));
			}
		}
	}

	IEnumerator LoadSceneinSeconds (float seconds)
	{
		yield return new WaitForSeconds(seconds);
		SceneManager.LoadScene("Menu");
	}
}
