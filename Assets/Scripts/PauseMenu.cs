using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pausa();  
        }
        Resume();
    }

    private void Resume()
    {
        GameIsPaused = false;
        Time.timeScale = 1f;
    }
    public void Pausa()
    {
        SceneManager.LoadScene("Pausa");
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

   

    public void Regresar()
    {
        SceneManager.LoadScene("Menu");
    }

}