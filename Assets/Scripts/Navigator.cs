using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigator : MonoBehaviour
{
    public static Navigator Instance;

    public GameObject upgradeMenu;
    public GameObject loseScreen;
    public GameObject winScreen;
    public GameObject timer;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void OpenUpgradeMenu()
    {
        upgradeMenu.SetActive(true);
        Time.timeScale = 0;
        Cursor.visible = true;
    }

    public void CloseUpgradeMenu()
    {
        upgradeMenu.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible = false;
    }

    public void OpenLoseScreen()
    {
        loseScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void OpenWinScreen()
    {
        winScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void TurnOnTimer()
    {
        timer.SetActive(true);
    }
}
