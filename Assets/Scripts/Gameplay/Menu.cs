using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Menu : MonoBehaviour {

	public void GoToScene(string scene)
	{
		SceneManager.LoadScene(scene);
	}		
}
