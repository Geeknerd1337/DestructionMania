using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    //variables
    public static bool isPaused = false;
    public GameObject pauseMenuUi;


    //Checks if you pressed the pause button. If you do, it pauses. Might change it to FixedUpdate later, not sure.
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Paused();
            }
        }
    }


    //Rseumes the game.
    public void Resume()
    {
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    //Pauses the game.
    void Paused()
    {
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    // Goes to main menu.
    public void Settings()
    {
        SceneManager.LoadScene("Options",LoadSceneMode.Additive);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

   
}
