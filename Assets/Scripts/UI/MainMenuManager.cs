using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using Cinemachine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.Video;

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
    Image anim;

    [Header("Game Controls")]
    [SerializeField]
    Image _imageControl;
    [SerializeField]
    Sprite _spritePCcontrols;
    [SerializeField]
    Sprite _spriteXboxControls;
    [SerializeField]
    Sprite _spritePS4Controls;

    [Header("Video Principal Cinematica")]
    [SerializeField]
    VideoPlayer videoPlayer_PrimeraCinematica;
    [SerializeField]
    GameObject canvasCinematica;

    PlayerInput playerInput;
    [SerializeField]
    AudioSource mainMusic;
    bool canPlayCinematic;
    int firstCinematic;
    [SerializeField]
    LevelLoader levelLoader;
    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        anim.DOFade(0, 1);
    }
    private void Start()
    {
        

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
        if (PlayerPrefs.HasKey("firstCinematic"))
        {
            canPlayCinematic = false;
        }
        else
        {
            PlayerPrefs.SetInt("firstCinematic", 0);
            canPlayCinematic = true;
        }
        if (canPlayCinematic)
        {
            anim.DOFade(1, 1);
            yield return new WaitForSeconds(1f);
            PlayCinematica();
            yield return new WaitForSeconds((float)videoPlayer_PrimeraCinematica.length + 1);
            canvasCinematica.SetActive(false);
            levelLoader.LoadScene();
        }
        else
        {
            anim.DOFade(1, 1);
            yield return new WaitForSeconds(1f);
            levelLoader.LoadScene();
        }
        
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
    void PlayCinematica()
    {
        mainMusic.DOFade(0, 1);
        canvasCinematica.SetActive(true);
        videoPlayer_PrimeraCinematica.Play();
       
    }
}
