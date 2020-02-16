using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using Cinemachine;

public class MainMenuManager : MonoBehaviour
{
    [Header("Canvas")]
    
    [SerializeField] GameObject canvasMainMenu;
    [SerializeField] GameObject canvasOptions;
    [SerializeField] GameObject canvasPlay;
    [SerializeField] RectTransform rectOptions;
    [SerializeField] RectTransform rectPlay;
    [Header("Ajustes RectTransform")]
    [SerializeField] RectTransform[] rectText;
    [SerializeField] RectTransform[] rectComponents;
    [SerializeField] RectTransform rectReturn;
    [SerializeField] RectTransform rectTextOptions;
    [Header("Buttons CanvasPlay")]
    [SerializeField] RectTransform rectButtonsPlay_1;
    [SerializeField] RectTransform rectButtonsPlay_2;

    [Header("Animator")]
    [SerializeField] Animator animFocus;
    [SerializeField] Animator animFocusPlay;
    [Header("Camara")]
    [SerializeField] Transform cam;
    [SerializeField] Vector3 initialPosition;
    [SerializeField] Vector3 endPosition;


    bool isFocus;


    private void Start()
    {
        canvasOptions.SetActive(false);
        canvasPlay.SetActive(false);
        cam.transform.position = initialPosition;
    }

    //Metodos Main Menu
    public void Play()
    {
        
        StartCoroutine(PlayAnimation());
    }
    public void NewGame()
    {
        SceneManager.LoadScene("GamePlayScreen");
    }
    public void Options()
    {
        StartCoroutine(OptionsAnimation());
    }
    void EnableCanvasOptions()
    {
        canvasOptions.SetActive(true);

    }
    void DisableCanvasOptions()
    {
        canvasOptions.SetActive(false);

    }
    public void ReturnOptions()
    {
        StartCoroutine(ReturnOptionsAnimation());

    }
    public void ExitStone()
    {
        StartCoroutine(ReturnPlayAnimation());




    }
    public void Exit()
    {
        Application.Quit();
    }

    IEnumerator OptionsAnimation()
    {
        isFocus = true;
        animFocus.SetBool("isFocus", isFocus);
        rectPlay.DOAnchorPos(new Vector2(-1000, 0), 0.3f).SetEase(Ease.InQuad);
        rectOptions.DOAnchorPos(new Vector2(0, 650), 0.3f).SetEase(Ease.InQuad).OnComplete(() => EnableCanvasOptions());

        yield return new WaitForSeconds(0.3f);
        rectReturn.DOAnchorPos(new Vector2(0, 0), 0.3f).SetEase(Ease.InQuad);
        rectTextOptions.DOAnchorPos(new Vector2(0, 0), 0.3f).SetEase(Ease.InQuad);
        canvasMainMenu.SetActive(false);
        foreach (RectTransform r in rectText)
        {
            r.DOAnchorPos(new Vector2(0, 0), 0.3f).SetEase(Ease.InQuad);
            //yield return new WaitForSeconds(0.1f / 4);
        }
        foreach (RectTransform r in rectComponents)
        {
            r.DOAnchorPos(new Vector2(0, 0), 0.3f).SetEase(Ease.InQuad);
            //yield return new WaitForSeconds(0.1f / 4);
        }
    } 
    IEnumerator ReturnOptionsAnimation()
    {
        rectReturn.DOAnchorPos(new Vector2(0, -250), 0.3f).SetEase(Ease.OutQuad);
        rectTextOptions.DOAnchorPos(new Vector2(0, 152.5f), 0.3f).SetEase(Ease.OutQuad);

        foreach (RectTransform r in rectText)
        {
            r.DOAnchorPos(new Vector2(-1000, 0), 0.3f).SetEase(Ease.OutQuad);
           // yield return new WaitForSeconds(0.1f / 4);
        }
        foreach (RectTransform r in rectComponents)
        {
            r.DOAnchorPos(new Vector2(1000, 0), 0.3f).SetEase(Ease.OutQuad);
            //yield return new WaitForSeconds(0.1f / 4);
        }
        yield return new WaitForSeconds(0.3f);

        canvasMainMenu.SetActive(true);

        isFocus = false;
        animFocus.SetBool("isFocus", isFocus);
        rectPlay.DOAnchorPos(new Vector2(0, 0), 0.3f).SetEase(Ease.OutQuad);
        rectOptions.DOAnchorPos(new Vector2(0, 0), 0.3f).SetEase(Ease.OutQuad);
        yield return new WaitForSeconds(0.2f);
        DisableCanvasOptions();

    }
    IEnumerator PlayAnimation()
    {
        canvasPlay.SetActive(true);
        rectButtonsPlay_1.DOAnchorPos(new Vector2(0, 0), 0.3f).SetEase(Ease.InQuad);
        if (rectButtonsPlay_2 != null)
        {
            rectButtonsPlay_2.DOAnchorPos(new Vector2(0, 0), 0.3f).SetEase(Ease.InQuad);

        }
        cam.DOLocalMove(endPosition, 0.5f).SetEase(Ease.InSine);
        isFocus = true;
        animFocusPlay.SetBool("isFocus", isFocus);
        rectPlay.DOAnchorPos(new Vector2(-1000, 0), 0.3f).SetEase(Ease.InQuad);
        rectOptions.DOAnchorPos(new Vector2(-1000, 0), 0.3f).SetEase(Ease.InQuad);
        canvasPlay.SetActive(true);


        yield return new WaitForSeconds(0.3f);
        
        canvasMainMenu.SetActive(false);
       
    }
    IEnumerator ReturnPlayAnimation()
    {
        rectButtonsPlay_1.DOAnchorPos(new Vector2(-1500, 0), 0.3f).SetEase(Ease.OutQuad);
        if(rectButtonsPlay_2!= null)
        {
            rectButtonsPlay_2.DOAnchorPos(new Vector2(1500 , 0), 0.3f).SetEase(Ease.OutQuad);

        }
        isFocus = false;
        animFocusPlay.SetBool("isFocus", isFocus);
        cam.DOLocalMove(initialPosition, 0.3f).SetEase(Ease.OutSine);

        yield return new WaitForSeconds(0.4f);
        canvasPlay.SetActive(false);
        canvasMainMenu.SetActive(true);
        rectPlay.DOAnchorPos(new Vector2(0, 0), 0.3f).SetEase(Ease.OutQuad);
        rectOptions.DOAnchorPos(new Vector2(0, 0), 0.3f).SetEase(Ease.OutQuad);

    }

}
