using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = true;
    }
    public void Quit()
    {
        Application.Quit();
    }
}
