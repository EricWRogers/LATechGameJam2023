using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace OmnicatLabs.Managers
{
    public class Timer
    {
        public Timer(float _amountOfTime, List<UnityAction> _listeners)
        {
            amountOfTime = _amountOfTime;
            listeners = _listeners;
        }

        public float amountOfTime;
        public List<UnityAction> listeners;
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

        public void CreateTimer(float amountOfTime, UnityAction listener)
        {
            List<UnityAction> temp = new List<UnityAction>();
            temp.Add(listener);
            timers.Add(new Timer(amountOfTime, temp));
        }

        public void CreateTimer(float amountOfTime, List<UnityAction> listeners)
        {
            timers.Add(new Timer(amountOfTime, listeners));
        }

        public void CreateTimer(Timer newTimer)
        {
            timers.Add(newTimer);
        }

        private void Update()
        {
            foreach (Timer timer in timers)
            {
                timer.amountOfTime -= Time.deltaTime;

                if (timer.amountOfTime <= 0f)
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
                }
            }

            timers.RemoveAll(timer => timer.amountOfTime <= 0f);
        }
    }
}
