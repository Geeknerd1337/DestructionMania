using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{

public GameObject OptionsUI;


public void PlayGame()
{
SceneManager.LoadScene("");
}


public void QuitGame()
{
    Application.Quit();
}

public void Options()
{
    SceneManager.LoadSceneAsync("Options",LoadSceneMode.Additive);
    
}




}
