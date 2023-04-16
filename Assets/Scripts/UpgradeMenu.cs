using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMenu : MonoBehaviour
{
    public GameObject UpgradeMenuGO;
    public GameObject ControlsMenuGO;
    private GameObject currentMenu;

    private void Start()
    {
        if(currentMenu == null)
        {
            currentMenu = UpgradeMenuGO;
        }
    }

    public void OpenControls()
    {
        if(currentMenu != ControlsMenuGO)
        {
            currentMenu.SetActive(false);
            currentMenu = ControlsMenuGO;
            currentMenu.SetActive(true);
        }
    }
    public void OpenUpgrade()
    {
        if (currentMenu != UpgradeMenuGO)
        {
            currentMenu.SetActive(false);
            currentMenu = UpgradeMenuGO;
            currentMenu.SetActive(true);
        }
    }
}
