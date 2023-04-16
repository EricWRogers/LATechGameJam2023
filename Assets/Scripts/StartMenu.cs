using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{

    private void Start()
    {
        Cursor.visible = true;
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("EricAITest");
    }
}
