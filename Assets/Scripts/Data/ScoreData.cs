using System;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerScore", menuName = "ArkaPong/Create PlayerData", order = 0)]
public class ScoreData : ScriptableObject, ISerializationCallbackReceiver
{
    //Public Members
    [SerializeField] private int _playerScore = 0;
    [NonSerialized] private int _runtimePlayerScore;
    
    [SerializeField] private GameSettings gameSettings;
    
    //Public Methods
    public void UpdateScore() {
        _runtimePlayerScore += gameSettings.scoreBase;
        
        Debug.Log($"{name} Score Updated To: {_runtimePlayerScore}");
        
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
