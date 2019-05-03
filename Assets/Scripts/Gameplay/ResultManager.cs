using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour {

	public Text score;
	public Text resultTitle;
	// Use this for initialization
	void Start () 
	{
		if(Data.EMTPY_GRID && Data.SCORE > 0)
			resultTitle.text = "Felicitaciones Al Mas Groso del Universo";
		else if (Data.SCORE > 0)
			resultTitle.text = "Lo siento pero la princesa esta en otro castillo";
		else
			resultTitle.text = "Realmente Fracasado of Life!";
		
		score.text = Data.SCORE.ToString();	
	}
	
	public void ResetGame()
	{
		SceneManager.LoadScene("MainMenu");
	}
}
