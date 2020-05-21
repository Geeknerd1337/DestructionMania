using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{

//public string LeveltoLoad, Settings;


public Scenefader scenefader;

public void PlayGame()
{
    SceneManager.LoadScene("LevelSelect");
}


public void QuitGame()
{
    Application.Quit();
}

public void Settings()
{
    SceneManager.LoadScene("Settings");
    
}




}
