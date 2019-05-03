using System.Collections.Generic;
using UnityEngine;

namespace Events{
    public class GameEvent  { }

    public class ScoreEvent : GameEvent {
        public PlayerIds playerId = PlayerIds.None;
        public ScoreData scoreData;
        public Vector3 playerPosition;        
    }

    public class StartTimerEvent : GameEvent { }
    public class GameStartEvent : GameEvent { }
    public class GameOverEvent : GameEvent { }
}


