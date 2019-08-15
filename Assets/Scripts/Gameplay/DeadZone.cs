using UnityEngine;
using System.Collections;
using Events;

public class DeadZone : MonoBehaviour {

	[SerializeField] private Transform _player;
	[SerializeField] private PlayerIds _playerId;
	[SerializeField] private ScoreData _scoreData;
	
	private  ScoreEvent _scoreEvent = new ScoreEvent();

	private GameController _gameController;
	
	private void Start() {
		_scoreEvent.playerPosition = _player.position;
		_scoreEvent.playerId = _playerId;
		_scoreEvent.scoreData = _scoreData;
	}

	private void OnTriggerEnter(Collider col)
	{
		if(!col.CompareTag("Ball")) return;

		
		_scoreData.UpdateScore();
		
		EventController.TriggerEvent(_scoreEvent);
	}
}
