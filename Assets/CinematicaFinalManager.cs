using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CinematicaFinalManager : MonoBehaviour
{
    [SerializeField]
    VideoPlayer videoPlayer_CinematicaFinal;

    [SerializeField]
    GameObject canvasQuit;
    private void Awake()
    {
        Invoke("QuitCanvas", (float)videoPlayer_CinematicaFinal.length);
    }

    void QuitCanvas()
    {
        canvasQuit.SetActive(true);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
