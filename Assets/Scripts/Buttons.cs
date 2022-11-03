using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
       
    }

    public void StartClick()
    {
        SceneManager.LoadScene("Nivel_X 1");
        
    }

    public void QuitClick()
    {
        Application.Quit();
    }

}

