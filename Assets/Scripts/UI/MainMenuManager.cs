using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using Cinemachine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class MainMenuManager : MonoBehaviour
{
    [Header("Canvas")]
    [SerializeField]
    GameObject _canvasMainMenu;
    [SerializeField]
    GameObject _canvasSettings;
    [SerializeField]
    GameObject _canvasGameControls;
    [SerializeField]
    Animator anim;

    [Header("Game Controls")]
    [SerializeField]
    Image _imageControl;
    [SerializeField]
    Sprite _spritePCcontrols;
    [SerializeField]
    Sprite _spriteXboxControls;
    [SerializeField]
    Sprite _spritePS4Controls;


    PlayerInput playerInput;
    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    public void Play()
    {
        StartCoroutine(LoadSceneCoroutine("GameplayScreen_Bosque"));
    }
    //public void ActiveSettings()
    //{
    //    _canvasSettings.SetActive(true);
    //    _canvasMainMenu.SetActive(false);
    //}
    public void Quit()
    {
        Application.Quit();
    }
    public void ExitControls()
    {
        _canvasGameControls.SetActive(false);
    }
    IEnumerator LoadSceneCoroutine(string scene)
    {
        anim.SetTrigger("Start");
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(scene);
    }
    
    public void ChangeSpritesControlls()
    {
        switch (playerInput.currentControlScheme)
        {
            case "PS4":
                _imageControl.sprite = _spritePS4Controls;
                print("PS4");
                break;
            case "Xbox":
                _imageControl.sprite = _spriteXboxControls;
                print("Xbox");
                break;
            case "KeyboardMouse":
                print("KeyboardMouse");
                _imageControl.sprite = _spritePCcontrols;
                break;
        }
    }
}
