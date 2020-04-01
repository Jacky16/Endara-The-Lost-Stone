using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsManager : MonoBehaviour
{
    //[SerializeField] private MainMenuManager mainMenuManager;
    public GameObject canvasBeforeCanvasSettings;
    public GameObject canvasSettingsAudio;
    public GameObject canvasSettingsVideo;
    public GameObject canvasSettings;
  
    //Metodos Ajustes
    public void Audio()
    {
        canvasSettingsAudio.SetActive(true);
        canvasSettingsVideo.SetActive(false);
    }
    public void Video()
    {
        canvasSettingsVideo.SetActive(true);

        canvasSettingsAudio.SetActive(false);
    }
    public void Return()
    {
        canvasSettings.SetActive(false);
        canvasSettingsAudio.SetActive(false);
        canvasSettingsVideo.SetActive(false);
        canvasBeforeCanvasSettings.SetActive(true);
    }
    //public void ExitToMainMenu()
    //{
    //    canvasBeforeCanvasSettings.SetActive(true);
    //    this.gameObject.SetActive(false);
    //    canvasSettingsAudio.SetActive(false);
    //    canvasSettingsVideo.SetActive(false);
    //}
   
    //public void DisabledMenuSettings()
    //{
    //    canvasSettingsAudio.SetActive(false);
    //    canvasSettingsVideo.SetActive(false);
    //    canvasSettings.SetActive(false);
    //    canvasBeforeCanvasSettings.SetActive(true);
    //}
    
    
   
   
}
