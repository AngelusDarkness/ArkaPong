using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Events;
using UnityEngine;
using UnityEngine.Analytics;
using Vector3 = UnityEngine.Vector3;

public class Player : MonoBehaviour {    
    
    [Header("Key Settings")]
    [SerializeField] private KeyCode _leftKey;
    [SerializeField] private KeyCode _rightKey;

    [Header("Movement Range")]
    [SerializeField] private float _minPosOffset = 0;
    [SerializeField] private float _maxPosOffset = 0;

    [Header("Other Settings")] 
    [SerializeField] private float _forceMultiplier = 10;
        
    private int  _currentDirection;
    private bool _canMove = false;

    private void OnEnable() {
        EventController.AddListener<GameStartEvent>(OnGameStartEvent);
        EventController.AddListener<GameOverEvent>(OnGameOverEvent);
    }

    private void OnDisable() {
        EventController.RemoveListener<GameStartEvent>(OnGameStartEvent);
        EventController.RemoveListener<GameOverEvent>(OnGameOverEvent);
    }

    // Update is called once per frame
    private void Update() {

        if(!_canMove) return;
        
        var inputValue = (Input.GetKey(_rightKey)? 1 : 0) - (Input.GetKey(_leftKey)? 1 : 0);
        
        if(inputValue == 0) return;
        
        _currentDirection = inputValue;
        
        var pos = transform.position;
        pos.x = Mathf.Clamp(pos.x + inputValue, _minPosOffset, _maxPosOffset);
        transform.position = pos;
    }


    private void OnCollisionEnter(Collision other) {
        if (!other.collider.CompareTag("Ball")) return;
        
        var ball = other.collider;
        var rb = ball.GetComponent<Rigidbody>();        
        var force = (((_currentDirection < 0) ? Vector3.right : Vector3.left) + Vector3.up) * _forceMultiplier;

        rb.velocity = Vector3.zero;
        rb.AddForce(force, ForceMode.Impulse);

    }
    
    //Events
    private void OnGameStartEvent(GameStartEvent evt) {
        _canMove = true;
    }

    private void OnGameOverEvent(GameOverEvent evt) {
        _canMove = false;
    }
 
}
