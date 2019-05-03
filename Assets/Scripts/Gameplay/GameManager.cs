using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour 
{
	public GameObject ballPrefab;	
	public Transform initialPosition;
	public Text scoreLabel;	
	public Text lifeLabel;
	public int life = 3;	
	public float ballSpeed = 1;	
	public int gridRows = 0;
	public int gridColumns = 0;
	
	private int _score = 0;
	private int _totalBlocks;
	
	private GameObject _ball;
	
	void Start()
	{
		_totalBlocks = gridColumns * gridRows;
		UpdateUI();
	}
	
	public void StartGame()
	{		
		_ball = (GameObject)Instantiate(ballPrefab,
						   new Vector3(initialPosition.position.x, initialPosition.position.y + 4,initialPosition.position.z),
						   initialPosition.rotation);		
		
		_ball.GetComponent<Rigidbody>().isKinematic = false;
		_ball.GetComponent<Rigidbody>().useGravity = true;
		_ball.GetComponent<Rigidbody>().AddForce(ballSpeed,ballSpeed*2,0);
		
	}
	public void AddScore(int score)
	{
		_score += score;
		_totalBlocks--;
		
		if(_totalBlocks == 0)
		{
			Data.EMTPY_GRID = true;
			GameOver();
		}
			
			
		UpdateUI();
	}
	
	public void Die()
	{
		if(life > 0)
		{
			life -= 1;
			UpdateUI();	
			
			if(life == 0)
			{
				GameOver();
			}			
			else
			{
				GameObject.Destroy(_ball);
				StartGame();	
			}						
		}		
	}
		
	void UpdateUI()
	{
		scoreLabel.text = "Score: " + _score.ToString();
		lifeLabel.text = "Life: " + life.ToString();
	}
	
	void GameOver()
	{
		Data.SCORE = _score;
		SceneManager.LoadScene("Results");	
	}
	
	
}
