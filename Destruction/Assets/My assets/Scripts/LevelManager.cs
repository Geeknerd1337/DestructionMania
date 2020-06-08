using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [Header("Weapons")]
    public List<Weapon> levelWeapons;
    public int index;
    public Text chargeText;

    private float score;
    [SerializeField]
    private Shatter[] shatteredObjects;
    public Slider slide;
    public float slideSpd;


    public float graceTime;
    public float graceTimer;
    private bool started;


    // Start is called before the first frame update
    void Start()
    {
        shatteredObjects = FindObjectsOfType<Shatter>();
        score = 0f;
        foreach(Weapon w in levelWeapons)
        {
            w.gameObject.SetActive(false);
        }
        levelWeapons[index].gameObject.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        HandleWeaponScrolling();
        UpdateUI();

        if (!started)
        {
            if(CalculateSlider() > 0)
            {
                started = true;
            }
        }
        else
        {
            graceTimer += Time.deltaTime;
        }
    }

    void UpdateUI()
    {

        chargeText.text = levelWeapons[index].charges.ToString();
        slide.value = Mathf.Lerp(slide.value, CalculateSlider(), slideSpd * Time.deltaTime);
    }

    void HandleWeaponScrolling()
    {
        float scrollDelta = Input.GetAxis("Mouse ScrollWheel");
        if(scrollDelta > 0)
        {
            levelWeapons[index].gameObject.SetActive(false);
            index++;
            if (index >= levelWeapons.Count)
            {
                index = 0;
            }
        }else if(scrollDelta < 0)
        {
            levelWeapons[index].gameObject.SetActive(false);
            index--;
            if(index < 0)
            {
                index = levelWeapons.Count - 1;
            }
        }


            if (levelWeapons[index].charges > 0)
            {
                levelWeapons[index].gameObject.SetActive(true);
            }
            else
            {
            levelWeapons[index].gameObject.SetActive(false);
            index++;
                if (index >= levelWeapons.Count)
                {
                    index = 0;
                }
            }

    }

    private float CalculateSlider()
    {
        float f = 0;
        for(int i = 0; i < shatteredObjects.Length; i++)
        {
            if(shatteredObjects[i] == null)
            {
                f++;
            }
        }
        return f / shatteredObjects.Length;

    }
}
