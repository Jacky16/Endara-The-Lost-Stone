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
    private void Update()
    {
        Pause();
    }

    // Update is called once per frame
    public void Pause()
    {

        if (InputManager.playerInputs.PlayerInputs.Pause.triggered && !activePause)
        {
            activePause = !activePause;
            canvasPause.SetActive(activePause);
            Time.timeScale = 0f;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            PlayerMovement.canMove = false;
        }
        else if (InputManager.playerInputs.PlayerInputs.Pause.triggered && activePause)
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
    public void ExitToMainMenuFromOtherSceen()
    {
        SceneManager.LoadScene("MainMenuScreen");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
