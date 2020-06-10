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
        else
        {
            ResumeGame();
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


    }

    // Resumes Game.
  public  void ResumeGame()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        pauseMenuUi.SetActive(false);
    }

// Goes to Main menu
public void MainMenu()
{
    SceneManager.LoadScene("Menu");
}

public void Quit()
{
    Application.Quit();
}


}
