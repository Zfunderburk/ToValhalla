using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	
	public int enemiesKilled = 0;
	public Text winText;
	public Image fade;
	private bool isGameOver;

	void Update () {
		if(enemiesKilled == 4)
		{
			Color temp = winText.color;
			temp.a = 1f;
			winText.color = temp; 
//			Color temp1 = fade.color;
//			SceneManager.LoadScene("Menu");
			if(!isGameOver){
				isGameOver = true;
//				temp1.a = 5f * Time.deltaTime;
//				fade.color = temp; 
				StartCoroutine(LoadSceneinSeconds(5f));
			}
		}
	}

	IEnumerator LoadSceneinSeconds (float seconds)
	{
		yield return new WaitForSeconds(seconds);
		SceneManager.LoadScene("Menu");
	}
}
