using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using Cinemachine;

public class MainMenuManager : MonoBehaviour
{
    [Header("Canvas")]
    [SerializeField]
    GameObject _canvasMainMenu;
    [SerializeField]
    GameObject _canvasSettings;

    public void Play()
    {
        SceneManager.LoadScene("GameplayScreen");
    }
    public void ActiveSettings()
    {
        _canvasSettings.SetActive(true);
        _canvasMainMenu.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
