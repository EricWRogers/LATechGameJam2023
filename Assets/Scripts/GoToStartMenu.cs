using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToStartMenu : MonoBehaviour
{
    public void StartMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
