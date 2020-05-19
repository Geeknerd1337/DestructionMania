using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    //variables
    public static bool gameIsPaused;
    public GameObject pauseMenuUi;


    void Start()
    {
        pauseMenuUi.SetActive(false);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameIsPaused = !gameIsPaused;
            PauseGame();
        }

    }



    // Pauses Game.
    void PauseGame()
    {
        if (gameIsPaused)
        {
            Time.timeScale = 0f;
            AudioListener.pause = true;
            pauseMenuUi.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            AudioListener.pause = false;
            pauseMenuUi.SetActive(false);
        }
    }

    // Goes to settings.
    public void Settings()
    {
        SceneManager.LoadScene("Options", LoadSceneMode.Additive);
    }


    // Goes to Main menu
    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }


}
