using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;





public class SettingsManager : MonoBehaviour
{
    [SerializeField] private MainMenuManager mainMenuManager;
    public GameObject canvasSettingsAudio;
    public GameObject canvasSettingsVideo;
    public AudioMixer audioMixer;
    public GameObject canvasSettings;
    public GameObject canvasPauseManager;

    //Slider Variables
    [Header("Sliders Ajustes")]
    public Slider sliderVolumenGeneral;
    public Slider sliderVolumenFX;
    public Slider sliderVolumenMusica;

    //DropDown variables
    [Header("DropDown Ajustes")]
    public TMPro.TMP_Dropdown resolutionDropdown;
    public TMPro.TMP_Dropdown qualitySettingsDropdown;
    Resolution[] resolutions;

    float generalVolume;
    float fxVolume;
    float musicVolume;

    float currentVolumeGeneral;
    float currentVolumeFx;
    float curreVolumeMusic;

    private void Start()
    {
        ResolutionStart();

        sliderVolumenGeneral.value = PlayerPrefs.GetFloat("GeneralVolume");
        sliderVolumenMusica.value = PlayerPrefs.GetFloat("MusicVolume");
        sliderVolumenFX.value = PlayerPrefs.GetFloat("FxVolume");

    }
    void Update()
    {
        VolumeManager();
        
    }

    //Metodos Ajustes
    public void Audio()
    {
        canvasSettingsAudio.SetActive(true);
    }
    public void Video()
    {
        canvasSettingsVideo.SetActive(true);

        canvasSettingsAudio.SetActive(false);
    }
    public void Controles()
    {

    }
    public void ExitToMainMenu()
    {
        mainMenuManager.canvasMainMenu.SetActive(true);
        mainMenuManager.canvasAjustes.SetActive(false);
        canvasSettingsAudio.SetActive(false);
        canvasSettingsVideo.SetActive(false);
    }
   
    public void DisabledMenuSettings()
    {
        canvasSettingsAudio.SetActive(false);
        canvasSettingsVideo.SetActive(false);
        canvasSettings.SetActive(false);
        canvasPauseManager.SetActive(true);
    }
    public void VolumeManager()
    {

        //Asignar el valor del slider en las variables
        generalVolume = sliderVolumenGeneral.value;
        fxVolume = sliderVolumenFX.value;
        musicVolume = sliderVolumenMusica.value;
        //Asignar el valor de las variables en los player prefs
        PlayerPrefs.SetFloat("GeneralVolume", generalVolume);
        PlayerPrefs.SetFloat("FxVolume", fxVolume);
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);

        //Assignar los valores de playerprefs a los volumenes actuales

        currentVolumeGeneral = PlayerPrefs.GetFloat("GeneralVolume");
        currentVolumeFx = PlayerPrefs.GetFloat("FxVolume");
        curreVolumeMusic = PlayerPrefs.GetFloat("MusicVolume");

        generalVolume = currentVolumeGeneral;
        musicVolume = curreVolumeMusic;
        fxVolume = currentVolumeFx;



        audioMixer.SetFloat("generalVolume", currentVolumeGeneral);
        audioMixer.SetFloat("fxVolume", fxVolume);
        audioMixer.SetFloat("musicVolume", musicVolume);

    }
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width,resolution.height,Screen.fullScreen);
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
            string optionResolution = resolutions[i].width + "x" + resolutions[i].height +" "+ resolutions[i].refreshRate + "Hz";
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
