using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.Rendering;
public class VideoSettings : MonoBehaviour
{
    //DropDown variables
    [Header("DropDown Ajustes")]
    public TMPro.TMP_Dropdown resolutionDropdown;
    public TMPro.TMP_Dropdown qualitySettingsDropdown;
    //Resolution
    Resolution[] resolutions;

    [Header("Sliders")]
    [SerializeField]
    Slider _sliderContrast;
    [SerializeField]
    Slider _sliderBrightness;
    //Volume
    ColorAdjustments colorAdjustments;
    MotionBlur motionBlur;
    [SerializeField]
    Volume _volume;
    //Vsync
    bool isVsync = false;
    private void Start()
    {
        ColorAdjustments colorAd;
        if (_volume.profile.TryGet<ColorAdjustments>(out colorAd))
        {
            colorAdjustments = colorAd;
        }
        MotionBlur motionB;
        if (_volume.profile.TryGet<MotionBlur>(out motionB))
        {
            motionBlur = motionB;
        }
        _sliderContrast.value = colorAdjustments.contrast.value;
        _sliderBrightness.value = colorAdjustments.postExposure.value;

        //Valores Motion Bloor
        motionBlur.intensity.value = .5f;
        motionBlur.maximumVelocity.value = 200;
        motionBlur.minimumVelocity.value = 2;
        motionBlur.cameraRotationVelocityClamp.value = .1f;
        motionBlur.cameraMotionBlur.value = true;
    }
    private void OnEnable()
    {
        ResolutionStart();
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
    public void SetContrast()
    {
        colorAdjustments.contrast.value = _sliderContrast.value;
    }
    public void SetBrightness()
    {
        colorAdjustments.postExposure.value = _sliderBrightness.value;
    }
    public void setVsync()
    {
        isVsync =! isVsync;
        if (isVsync)
        {
            QualitySettings.vSyncCount = 1;
        }
        else
        {
            QualitySettings.vSyncCount = 0;
        }
    }
    public void ActiveMotionBloor(bool b)
    {
        motionBlur.active = b;
    }
}
