using System;
using Events;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerScore", menuName = "ArkaPong/Create PlayerData", order = 0)]
public class ScoreData : ScriptableObject, ISerializationCallbackReceiver
{
    //Private Members
    [SerializeField] private GameSettings gameSettings;
    [SerializeField] private PlayerIds _playerId = PlayerIds.None;
    [SerializeField] private int _playerScore = 0;
    [NonSerialized] private int _runtimePlayerScore;

    public PlayerIds PlayerID => _playerId;
    
    //Public Methods
    public void UpdateScore() {
        _runtimePlayerScore += gameSettings.scoreBase;
    }
    

    
    public int GetScore() {
        return _runtimePlayerScore;
    }

    
    //Unity Methods
    public void OnAfterDeserialize() {
        _runtimePlayerScore = _playerScore;
    }

    public void OnBeforeSerialize() { }
}
