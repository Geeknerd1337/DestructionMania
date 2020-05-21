using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scenefader : MonoBehaviour
{

    public Image image;
    public AnimationCurve fadeCurve;



    void Start()
    {
        StartCoroutine(FadeIn());
    }
    // Fades into levels
    IEnumerator FadeIn()
    {
        float t = 1f;

        while (t > 0f)
        {
            t -= Time.deltaTime;
            float a = fadeCurve.Evaluate(t);
            image.color = new Color(0f, 0f, 0f, a);
            yield return 0;
        }
    }


// This is to fade into level you loaded. Doesn't work right now.
/*
    public void Fadeto(string scene)
    {
        StartCoroutine(FadeOut(scene));
    }

    */
    IEnumerator FadeOut(string c)
    {
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime;
            float a = fadeCurve.Evaluate(t);
            image.color = new Color(0f, 0f, 0f, a);
            yield return 0;
        }

    //    SceneManager.LoadScene(c, LoadSceneMode.Additive);

    }

}
