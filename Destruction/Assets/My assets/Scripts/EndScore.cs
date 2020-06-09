using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScore : MonoBehaviour
{

    public Text scoreText;
    public bool startScore;
    private float score;
    public float scoreTarget;
    private LevelManager manager;
    private bool coStart;
    public string additionalText;
    public float endSlideValue;
    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startScore)
        {
            score = Mathf.MoveTowards(score, scoreTarget, 3000f * Time.deltaTime);

            if(score == scoreTarget && !coStart)
            {
                StartCoroutine("ScoreTally");
                coStart = true;
            }

            scoreText.text = Mathf.Round(score).ToString() + additionalText;
        }
        else
        {
            scoreText.text = "";

        }
    }

    IEnumerator ScoreTally()
    {
        for(int i = 0; i < 3; i++)
        {
            if(i == 0)
            {
                additionalText += "\nRemaining Charges: " + (1f + manager.GetTotalCharges() * 0.5).ToString() + "x";
                scoreTarget *= 1f + manager.GetTotalCharges() * 0.5f;


            }

            if(i == 1)
            {
                if(endSlideValue > 0.9f)
                {
                    additionalText += "\nExcellent Destruction: 1.1x";
                    scoreTarget *= 1.1f;
                }
            }

            if(i == 2)
            {
                if (endSlideValue >= 1f) {
                    additionalText += "\nTotal Destruction: 1.2x";
                    scoreTarget *= 1.2f;
                }
            }
            yield return new WaitForSeconds(1f);
        }
    }
}
