using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GemaManager : MonoBehaviour
{
    enum States { Selected,Unselected,Mouseover};
    States myStates;
    bool isMouseOver;
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
                //myStates = States.Selected;
                Selected();
            }
            transform.DOLocalRotate(new Vector3(90, 360, 0), 5, RotateMode.FastBeyond360).SetEase(Ease.Linear);

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
        transform.DOLocalMoveZ(-0.2f, 0.3f).SetEase(Ease.InCubic).OnStart(() => ActiveCanvasMainMenu()).OnPlay(() => DoAnimationsButtons());
        transform.DOLocalRotate(new Vector3(90, 360, 0), 5, RotateMode.FastBeyond360).SetEase(Ease.Linear);
    }
    public void Unselected()
    {
        //transform.DOLocalRotate(new Vector3(90, 0, 0), 2.5f, RotateMode.FastBeyond360).SetEase(Ease.Linear); 

        transform.DOLocalMoveZ(0f, 1f).SetEase(Ease.OutCubic).OnPlay(() => DoRewindAnimationsButtons());

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


    }


}
