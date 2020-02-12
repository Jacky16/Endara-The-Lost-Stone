using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject canvasMainMenu;
    public GameObject canvasAjustes;

    private void Start()
    {
        canvasAjustes.SetActive(false);
    }

    //Metodos Main Menu
    public void Play()
    {
        SceneManager.LoadScene("GamePlayScreen");
    }
    public void Ajustes()
    {
       
        canvasAjustes.SetActive(true);
        canvasMainMenu.SetActive(false);
    }
    public void ContenidoExtra()
    {

    }
    public void Creditos()
    {

    }
    public void Exit()
    {
        Application.Quit();
    }

   
}
