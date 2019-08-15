
using System.Collections;
using Events;
using TMPro;

using UnityEngine;

public class UIController : MonoBehaviour {
    [Header("Game Settings")] 
    [SerializeField] private GameSettings _gameSettings;
    
    [Header("UI Settings")]
    [SerializeField] private TMP_Text[] _playerScores;        
    [SerializeField] private TMP_Text _timerText;
    [SerializeField] private TMP_Text _startTimerText;
    [SerializeField] private TMP_Text _gameOverText;
    [SerializeField] private TMP_Text _winnerText;

    private readonly WaitForSeconds _oneSecond = new WaitForSeconds(1);
    
    //Unity Methods
    private void Start() {
        _startTimerText.text = $"{_gameSettings.startTime}";
        _timerText.text = $"{_gameSettings.matchTime}";
        
        _gameOverText.text = string.Empty;
        _winnerText.text = string.Empty;
    }

    private void OnEnable() {
        EventController.AddListener<ScoreEvent>(OnScoreEvent);
        EventController.AddListener<GameStartEvent>(OnGameStartEvent);
        EventController.AddListener<StartTimerEvent>(OnStartTimerEvent);
        EventController.AddListener<GameOverEvent>(OnGameOverEvent);
    }

    private void OnDisable() {
        EventController.RemoveListener<ScoreEvent>(OnScoreEvent);
        EventController.RemoveListener<GameStartEvent>(OnGameStartEvent);
        EventController.RemoveListener<StartTimerEvent>(OnStartTimerEvent);
        EventController.RemoveListener<GameOverEvent>(OnGameOverEvent);
    }
    
    //Private Methods
    private IEnumerator UpdateStartGameUI() {
        var timer = _gameSettings.startTime;

        while (timer > -1) {
            yield return _oneSecond;
            _startTimerText.text = $"{timer}";
            timer--;                
        }

        _startTimerText.enabled = false;
    }

    private IEnumerator UpdateGamePlayUI() {
        var timer = _gameSettings.matchTime;

        while (timer > -1) {
            yield return _oneSecond;
             
            _timerText.text = $"Time: {timer}";
            timer--;                
        }
    }

    //Events
    private void OnScoreEvent(ScoreEvent evt) {
        var playerId = (int) evt.playerId;
        
        _playerScores[playerId].text = $"Player {playerId + 1}: {evt.scoreData.GetScore()}";
    }

    private void OnStartTimerEvent(StartTimerEvent evt) {
        StartCoroutine(UpdateStartGameUI());
        
    }

    private void OnGameStartEvent(GameStartEvent evt) {
        StartCoroutine(UpdateGamePlayUI());
    }

    private void OnGameOverEvent(GameOverEvent evt) {
        _gameOverText.text = "Game Over";
        _winnerText.text = $"Winner {evt.winnerId}";
    }
    
}
