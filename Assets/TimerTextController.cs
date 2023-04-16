using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerTextController : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    private void Start()
    {
        timerText.SetText($"{(int)FindObjectOfType<Transmitter>().endGameTimer.TimeLeft / 60} : {(int)FindObjectOfType<Transmitter>().endGameTimer.TimeLeft % 60}");
    }

    private void Update()
    {
        if (FindObjectOfType<Transmitter>().endGameTimer.TimeLeft > 10)
            timerText.SetText($"{(int)FindObjectOfType<Transmitter>().endGameTimer.TimeLeft / 60} : {(int)FindObjectOfType<Transmitter>().endGameTimer.TimeLeft % 60}");
        else
        {
            timerText.SetText($"{(int)FindObjectOfType<Transmitter>().endGameTimer.TimeLeft / 60} : 0{(int)FindObjectOfType<Transmitter>().endGameTimer.TimeLeft % 60}");
        }
    }
}
