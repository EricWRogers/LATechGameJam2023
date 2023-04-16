using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigator : MonoBehaviour
{
    public static Navigator Instance;

    public GameObject upgradeMenu;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void OpenUpgradeMenu()
    {
        upgradeMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void CloseUpgradeMenu()
    {
        upgradeMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
