using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Events;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    [Header("Ball Settings")]
    [SerializeField] private GameObject _ball;
    [SerializeField] private GameSettings _gameSettings;

    [Header("Data Settings")] 
    [SerializeField] private ScoreData[] _playersScore;

    private WaitForSeconds _oneSecond = new WaitForSeconds(1);
    private WaitForSeconds _gameplayTimer;

    private StartTimerEvent _startTimerEvent = new StartTimerEvent();
    private GameStartEvent _gameStartEvent = new GameStartEvent();
    private GameOverEvent _gameOverEvent = new GameOverEvent();

    //Unity Methods
    private void Start() {
        StartCoroutine(StartGame());
    }

    private void OnEnable() {
        EventController.AddListener<ScoreEvent>(OnScoreEvent);
    }

    private void OnDisable() {
        EventController.RemoveListener<ScoreEvent>(OnScoreEvent);
    }
    
    //Private
    private IEnumerator StartGame() {
        var timer = _gameSettings.startTime;
        EventController.TriggerEvent(_startTimerEvent);
        
        while (timer > -1) {
            yield return _oneSecond;
            timer--;                
        }
        StartCoroutine(UpdateGamePlayTime());
        EventController.TriggerEvent(_gameStartEvent);
        
        
    }
    
    private IEnumerator UpdateGamePlayTime() {
        var timer = _gameSettings.matchTime;
        
        while (timer > -1) {
            yield return _oneSecond;
            timer--;
        }
        GameOver();
    }

    private void GameOver() {
        var winner = _playersScore.OrderBy(score => score.GetScore()).First();
        
        PlayerPrefs.SetInt("PlayerID", (int)winner.PlayerID);
        PlayerPrefs.SetInt("Score", winner.GetScore());
        
        PlayerPrefs.Save();
        
        _gameOverEvent.winnerId = winner.PlayerID;
        EventController.TriggerEvent(_gameOverEvent);

        
    }

    //Events
    private void OnScoreEvent(ScoreEvent evt) {
        _ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        _ball.transform.position = evt.playerPosition;   
    }
}
