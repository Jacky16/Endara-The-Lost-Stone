using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GemaManager : MonoBehaviour
{
    enum States { Selected,Unselected,Mouseover};
    States myStates;
    bool isMouseOver;
    bool isInMenu;
    [SerializeField]
    GameObject canvasMainMenu;
    [SerializeField]
    RectTransform rectTransformPlayButton;
    [SerializeField]
    RectTransform rectTransformExitButton;
    [SerializeField]
    RectTransform rectTransformSettingsButton;
    private void Start()
    {

        Unselected();
    }
    private void Update()
    {
        myStates = States.Unselected;
        if (isMouseOver)
        {
            if (Input.GetMouseButtonDown(0))
            {
              Selected(); 
            }
            transform.DOLocalRotate(new Vector3(90, 180, 0), 2, RotateMode.FastBeyond360);
            transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 2);

        }
        else
        {
            transform.DOLocalRotate(new Vector3(90, 0, 0), 2, RotateMode.FastBeyond360);
            transform.DOScale(new Vector3(1, 1,1), 2);
        }


    }
    private void OnMouseOver()
    {
        
        isMouseOver = true;

    }
  
    private void OnMouseExit()
    {
        isMouseOver = false;
     

    }
   
    public void Selected()
    {
        if(!isInMenu)
        {
            transform.DOScale(new Vector3(1, 1, 1), 3);
            transform.DOLocalMoveZ(-0.2f, 0.3f).SetEase(Ease.InCubic).OnStart(() => ActiveCanvasMainMenu()).OnPlay(() => DoAnimationsButtons());
            transform.DOLocalRotate(new Vector3(90, 360, 0), 0.4f);
        }

        
    }
    public void Unselected()
    {
        //transform.DOLocalRotate(new Vector3(90, 0, 0), 2.5f, RotateMode.FastBeyond360).SetEase(Ease.Linear); 
        transform.DOLocalMoveZ(0f, 1f).SetEase(Ease.OutCubic).OnPlay(() => DoRewindAnimationsButtons());
        transform.DOLocalRotate(new Vector3(90, 0, 0), 0.4f);


    }
    public void ActiveCanvasMainMenu()
    {
        canvasMainMenu.SetActive(true);

    }
    public void DesactiveCanvasMainMenu()
    {

        canvasMainMenu.SetActive(false);

    }
    public void DoAnimationsButtons()
    {
        rectTransformPlayButton.DOAnchorPos(new Vector2(550, 180), 0.2f).SetEase(Ease.InCubic);
        rectTransformExitButton.DOAnchorPos(new Vector2(550, -180), 0.2f).SetEase(Ease.InCubic);
        rectTransformSettingsButton.DOAnchorPos(new Vector2(-650, -0), 0.2f).SetEase(Ease.InCubic);
        //Escala
        rectTransformPlayButton.DOScale(new Vector2(1, 1), 0.2f).SetEase(Ease.OutCubic);
        rectTransformExitButton.DOScale(new Vector2(1, 1), 0.2f).SetEase(Ease.OutCubic);
        rectTransformSettingsButton.DOScale(new Vector2(1, 1), 0.2f).SetEase(Ease.OutCubic);
        isInMenu = true;


    }
    public void DoRewindAnimationsButtons()
    {
        rectTransformPlayButton.DOAnchorPos(new Vector2(0, 0), 0.2f).SetEase(Ease.OutCubic).OnComplete(() => DesactiveCanvasMainMenu());
        rectTransformExitButton.DOAnchorPos(new Vector2(0, 0), 0.2f).SetEase(Ease.OutCubic);
        rectTransformSettingsButton.DOAnchorPos(new Vector2(0, -0), 0.2f).SetEase(Ease.OutCubic);
        //Escala
        rectTransformPlayButton.DOScale(new Vector2(0, 0), 0.2f).SetEase(Ease.OutCubic);
        rectTransformExitButton.DOScale(new Vector2(0, 0), 0.2f).SetEase(Ease.OutCubic);
        rectTransformSettingsButton.DOScale(new Vector2(0, 0), 0.2f).SetEase(Ease.OutCubic);

        isInMenu = false;


    }


}
