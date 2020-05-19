using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    //Variables
    public string sceneToLoad;
    AsyncOperation loadingOperation;
    public Slider progressBar;

    public CanvasGroup canvasGroup;

    public GameObject loadingScreen;


// Start fucntion. It makes the loading screen active, also allowing it to load in the level.
    void Start()
    {
        loadingScreen.SetActive(true);
        loadingOperation = SceneManager.LoadSceneAsync(sceneToLoad);
        StartCoroutine(FadeLoadingScreen(2));

    }
    
    //This updates on the slider, showing progress.
    void Update()
    {
        progressBar.value = Mathf.Clamp01(loadingOperation.progress / 0.9f);
    }

    //This is to fade in the loading screen.
    IEnumerator FadeLoadingScreen(float duration)
    {
        float startValue = canvasGroup.alpha;
        float time = 0;

        while (time < duration)
        {
            canvasGroup.alpha = Mathf.Lerp(startValue, 1, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        canvasGroup.alpha = 1;
    }
}
