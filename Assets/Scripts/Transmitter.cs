using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Transmitter : MonoBehaviour
{
    public UnityEvent distanceWarning;
    public UnityEvent finalDistanceWarning;
    public UnityEvent lostConnection;
    public UnityEvent returnedToSafeRange;
    public UnityEvent startEndGame;
    public UnityEvent youWon;
    public SuperPupSystems.Helper.Timer endGameTimer;

    public bool distanceWarningActive = false;
    public bool finalDistanceWarningActive = false;
    public bool lostConnectionActive = false;

    public float safeDistanceArea = 250.0f;
    public float finalWarningDistance = 275.0f;
    public float lostConnectionDistance = 300.0f;

    private GameObject player;
    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        player = FindObjectOfType<NewShipController>().gameObject;
        lineRenderer.SetPosition(1 ,player.transform.position - player.transform.up);
    }

    void Update()
    {
        lineRenderer.SetPosition(1, player.transform.position - player.transform.up);
    }

    public void UnlockAllUpgrades()
    {
        startEndGame.Invoke();
        endGameTimer.StartTimer();
    }

    public void FinalTimerEnded()
    {
        youWon.Invoke();
    }

    public void CheckConnection()
    {
        float distance = Vector3.Distance(player.gameObject.transform.position, transform.position);
        
        if (safeDistanceArea > distance)
        {
            if (distanceWarningActive || finalDistanceWarningActive)
                returnedToSafeRange.Invoke();
            
            distanceWarningActive = false;
            finalDistanceWarningActive = false;
            return;
        }

        if (safeDistanceArea < distance && !distanceWarningActive)
        {
            distanceWarningActive = true;
            distanceWarning.Invoke();
        }

        if (finalWarningDistance < distance && !finalDistanceWarningActive)
        {
            finalDistanceWarningActive = true;
            finalDistanceWarning.Invoke();
        }

        if (lostConnectionDistance < distance && !lostConnectionActive)
        {
            lostConnectionActive = true;
            lostConnection.Invoke();
        }
    }
}
