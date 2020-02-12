using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoSettings : MonoBehaviour
{
    //DropDown variables
    [Header("DropDown Ajustes")]
    public TMPro.TMP_Dropdown resolutionDropdown;
    public TMPro.TMP_Dropdown qualitySettingsDropdown;
    Resolution[] resolutions;
    void Start()
    {
        ResolutionStart();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void SetFullScree(bool fullScreen)
    {
        Screen.fullScreen = fullScreen;
    }
    public void SetQuality()
    {
        QualitySettings.SetQualityLevel(qualitySettingsDropdown.value);
    }
    public void ResolutionStart()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> resolutionsList = new List<string>();
        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string optionResolution = resolutions[i].width + "x" + resolutions[i].height + " " + resolutions[i].refreshRate + "Hz";
            resolutionsList.Add(optionResolution);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(resolutionsList);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }
}
