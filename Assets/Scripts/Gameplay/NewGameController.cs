using System;
using Events;
using UnityEngine;

namespace Gameplay {
    public class NewGameController : MonoBehaviour {

        [SerializeField] private GameObject _ball;
        //Comenzar el juego
        //Recibir eventos de score

        private void Start() {
            //Aplicar fueza inicial a la bola en una direction.
            
            
        }

        private void OnEnable() {
            EventController.AddListener<ScoreEvent>(OnScoreEvent);
        }

        private void OnDisable() {
            EventController.RemoveListener<ScoreEvent>(OnScoreEvent);
        }
        
        
        //Events
        private void OnScoreEvent(ScoreEvent evt) {
            //Mostrar quien hizo el gol.
            
            
            
        }
    }
}