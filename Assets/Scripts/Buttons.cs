using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{

    public static bool GameIsPaused = false;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
       
    }

    public void StartClick()
    {
        SceneManager.LoadScene("EscenaPrueba");
        
    }

    public void QuitClick()
    {
        Application.Quit();
    }

    public void Continue()
    {
        SceneManager.LoadScene("EscenaPrueba");
    }

    public void Regresar()
    {
        SceneManager.LoadScene("Menu");
    }

}

