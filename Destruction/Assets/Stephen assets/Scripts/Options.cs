using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Options : MonoBehaviour
{

    //variables
     public GameObject options;
    public AudioMixer audioMixer;

    public Dropdown resolutionDropdown;
    Resolution[] resolutions;

   

    //Start menu for getting resolutions.
    void Start()
    {
        

        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();


        int currentResolutionIndex = 0;
        //For each resolution the PC gets, it adds it to the list.
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);


            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }



        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

    }


//Setting the Resolution from the dropdown.
public void setResolution (int reoslutionIndex)
{
    Resolution resolution = resolutions[reoslutionIndex];
    Screen.SetResolution(resolution.width,resolution.height,Screen.fullScreen);
}

    //For controlling volume.
    public void SetVolume(float Vol)
    {
        audioMixer.SetFloat("Volume", Vol);

    }

    //For setting up graphic settings.
    public void SetGraphics(int graphicIndex)
    {
        QualitySettings.SetQualityLevel(graphicIndex);
    }
    //Toggling full screen.
    public void SetFullscreen(bool isfullscreen)
    {
        Screen.fullScreen = isfullscreen;
    }



    public void goBack()
    {
        options.SetActive(false);
    }

}
