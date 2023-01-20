using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{
        public static EventManager Instance;
    
        private Dictionary<string, Action> eventDictionary0;
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        public void AddListener(string eventName, Action listener)
        {
            eventDictionary0 ??= new Dictionary<string, Action>();
            if (eventDictionary0.TryGetValue(eventName, out var thisEvent))
            {
                thisEvent += listener;
                eventDictionary0[eventName] = thisEvent;
            }
            else
            {
                thisEvent += listener;
                eventDictionary0.Add(eventName, thisEvent);
            }
        }

        private void ClearListeners(Scene scene)
        {
            eventDictionary0?.Clear();
        }
        

        public void TriggerEvent(string eventName)
        {
            if (eventDictionary0 == null)
            {
                Debug.LogWarning("[EventManager] TriggerEvent:: Event couldn't be triggered because there are no listeners");
                return;
            }

            if (eventDictionary0.TryGetValue(eventName, out var thisEvent))
            {
                thisEvent.Invoke();
            }
        }
}

    public static class EventName
    {
        public static readonly string GameStarted = "GameStarted";
        public static readonly string SpawnEnemies = "SpawnEnemies";
        public static readonly string LevelFailed = "LevelFailed";
        public static readonly string ShowMainMenu = "ShowMainMenu";

    }
