using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

	public void newGameBtn (string newGameLevel)
	{
		SceneManager.LoadScene (newGameLevel);
	}

	public void ExitGame ()
	{
		Application.Quit ();
	}
}
