using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseManager : MonoBehaviour
{
    [SerializeField] GameObject canvasPause;
    [SerializeField] GameObject canvasSettings;
    [SerializeField] KeyCode pauseKeyCode;
    void Start()
    {
        canvasPause.SetActive(false);
        canvasSettings.SetActive(false);
    }
    private void Update()
    {
        Pause();
    }

    // Update is called once per frame
    public void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            canvasPause.SetActive(true);
            Time.timeScale = 0.01f;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
    public void Resume()
    {
        canvasPause.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void Settings()
    {
        canvasSettings.SetActive(true);
        canvasPause.SetActive(false);
    }
    public void ExitToMainMenuFromOtherSceen()
    {
        SceneManager.LoadScene("MainMenuScreen");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
