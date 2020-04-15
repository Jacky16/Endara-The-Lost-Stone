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

    void Start()
    {
        canvasPause.SetActive(false);
        canvasSettings.SetActive(false);
    }
    

    public void Pause()
    {
        print(activePause);
        if (!activePause)
        {
            activePause = !activePause;
            canvasPause.SetActive(activePause);
            Time.timeScale = 0f;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            PlayerMovement.canMove = false;
        }
        else if (activePause)
        {
            activePause = !activePause;
            canvasPause.SetActive(activePause);
            Time.timeScale = 1f;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            PlayerMovement.canMove = true;
            foreach (GameObject g in _canvasInsideSettings)
            {
                g.SetActive(false);
            }
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
