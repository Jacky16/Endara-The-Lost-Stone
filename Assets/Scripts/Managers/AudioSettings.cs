using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    //Slider Variables
    [Header("Sliders Ajustes")]
    public Slider sliderVolumenGeneral;
    public Slider sliderVolumenFX;
    public Slider sliderVolumenMusica;
    [Header("Audio Mixer")]
    public AudioMixer audioMixer;

    float generalVolume;
    float fxVolume;
    float musicVolume;

    float currentVolumeGeneral;
    float currentVolumeFx;
    float curreVolumeMusic;
    void Start()
    {
        sliderVolumenGeneral.value = PlayerPrefs.GetFloat("GeneralVolume");
        sliderVolumenMusica.value = PlayerPrefs.GetFloat("MusicVolume");
        sliderVolumenFX.value = PlayerPrefs.GetFloat("FxVolume");

        sliderVolumenFX.minValue = -60;
        sliderVolumenGeneral.minValue = -60;
        sliderVolumenMusica.minValue = -60;
      
    }

    // Update is called once per frame
    void Update()
    {
        //VolumeManager();
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
}
