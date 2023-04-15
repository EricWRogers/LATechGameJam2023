using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace OmnicatLabs.Managers
{
    public class Timer
    {
        public Timer(float _amountOfTime, List<UnityAction> _listeners, bool _autoRestart)
        {
            amountOfTime = _amountOfTime;
            listeners = _listeners;
            timeRemaining = amountOfTime;
            autoRestart = _autoRestart;
        }

        public float amountOfTime;
        public List<UnityAction> listeners;
        public float timeRemaining;
        public bool autoRestart;
    }

    public class TimerManager : MonoBehaviour
    {
        public static TimerManager Instance;
        private List<Timer> timers = new List<Timer>();

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        public void CreateTimer(float amountOfTime, UnityAction listener, bool autoRestart = false)
        {
            List<UnityAction> temp = new List<UnityAction>();
            temp.Add(listener);
            timers.Add(new Timer(amountOfTime, temp, autoRestart));
        }

        public void CreateTimer(float amountOfTime, List<UnityAction> listeners, bool autoRestart = false)
        {
            timers.Add(new Timer(amountOfTime, listeners, autoRestart));
        }

        public void CreateTimer(Timer newTimer)
        {
            timers.Add(newTimer);
        }

        private void Update()
        {
            foreach (Timer timer in timers)
            {
                timer.timeRemaining -= Time.deltaTime;

                if (timer.timeRemaining <= 0f)
                {
                    if (timer.listeners.Count == 1)
                    {
                        timer.listeners[0].Invoke();
                    }
                    else
                    {
                        foreach (UnityAction listener in timer.listeners)
                        {
                            listener.Invoke();
                        }
                    }

                    if (timer.autoRestart)
                    {
                        timer.timeRemaining = timer.amountOfTime;
                    }
                }
            }

            timers.RemoveAll(timer => timer.timeRemaining <= 0f && !timer.autoRestart);

        }
    }
}
