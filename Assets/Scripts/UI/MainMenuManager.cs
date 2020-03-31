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
    [SerializeField]
    Animator anim;

    public void Play()
    {
        StartCoroutine(LoadSceneCoroutine("GameplayScreen_Bosque"));
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
    IEnumerator LoadSceneCoroutine(string scene)
    {
        anim.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(scene);



    }
}
