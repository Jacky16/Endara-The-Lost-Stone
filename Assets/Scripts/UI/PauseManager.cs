using Boo.Lang;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseManager : MonoBehaviour
{
    [SerializeField] GameObject canvasPause;
    [SerializeField] GameObject canvasSettings;
    [SerializeField] GameObject[] _canvasInsideSettings;
    bool activePause = false;
    Boo.Lang.List<AudioSource> audioSources = new Boo.Lang.List<AudioSource>();

    void Start()
    {
        canvasPause.SetActive(false);
        canvasSettings.SetActive(false);
    }
    

    public void Pause()
    {
        foreach(AudioSource a in FindObjectsOfType<AudioSource>())
        {
            if (a.isPlaying)
            {
                audioSources.Add(a);
            }
        }
        if (!activePause)
        {
            activePause = !activePause;
            canvasPause.SetActive(activePause);
            Time.timeScale = 0f;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            PlayerMovement.canMove = false;
            foreach (AudioSource a in audioSources)
            {
                a.Pause();
            }

        }
        else if (activePause)
        {
            activePause = !activePause;
            canvasPause.SetActive(activePause);
            Time.timeScale = 1f;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            PlayerMovement.canMove = true;
            foreach (AudioSource a in audioSources)
            {
                a.Play();
            }
            audioSources.Clear();
        }
    }
    public void Resume()
    {
        activePause = !activePause;
        canvasPause.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        PlayerMovement.canMove = true;
        foreach (AudioSource a in audioSources)
        {
            a.Play();
        }
        audioSources.Clear();

    }
    public void Settings()
    {
        canvasSettings.SetActive(true);
        canvasPause.SetActive(false);
    }
    public void ExitToMainMenu()
    {
        SceneManager.LoadScene("MainMenuScreen");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
