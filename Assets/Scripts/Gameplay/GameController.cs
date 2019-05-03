using System.Collections;
using System.Collections.Generic;
using Events;
using UnityEngine;

public class GameController : MonoBehaviour {
    [SerializeField] private GameObject _ball;
    [SerializeField] private GameSettings gameSettings;

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
        var timer = gameSettings.startTime;
        EventController.TriggerEvent(_startTimerEvent);
        
        while (timer > -1) {
            yield return _oneSecond;
            timer--;                
        }
        
        EventController.TriggerEvent(_gameStartEvent);
    }

    //Events
    private void OnScoreEvent(ScoreEvent evt) {
        _ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        _ball.transform.position = evt.playerPosition;   
    }
}
