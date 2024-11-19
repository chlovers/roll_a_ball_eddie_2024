using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausescreen;
    private bool ispaused;



     void Start()
    {
        ispaused = false;
        Time.timeScale = 1;
        pausescreen.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!ispaused)
            {
                Pause();
            }
            else
            {
                Continue();
            }
        }
    }

    public void Pause()
    {
        
        pausescreen.SetActive(true);
        Time.timeScale = 0;
        ispaused = true;

    }

    public void Continue()
    {
        
        pausescreen.SetActive(false);
        Time.timeScale = 1;
        ispaused = false;

    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");

    }


}
