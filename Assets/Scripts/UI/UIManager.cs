using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    [Header("Canvas")]
    [SerializeField]
    GameObject _canvasCatchObject;
    [SerializeField]
    GameObject _canvasRotateObject;

    [Header("RectTransform Buttons")]
    [SerializeField]
    RectTransform _rectTransformButtonCatchObject;
    [SerializeField]
    RectTransform[] _rectTransformsButtonsRotate;
    [SerializeField]
    RectTransform _rectTransformDropButton;
    //Image Catcht Object 
    [Header("Image Catcht Object")]
    [SerializeField]
    Image _imageCatchObject;

    //Image Rotate Object
    [Header("Image Rotate Object")]
    [SerializeField]
    Image _imageRotateObject_L;
    [SerializeField]
    Image _imageRotateObject_R;

    [Header("Image Drop Object")]
    [SerializeField]
    Image _imageDrop;

    //Keyboard/Mouse
    [Header("Sprites Keyboard")]
    [SerializeField]
    Sprite _spriteCatchObject_Keyboard;

    //Xbox
    [Header("Sprites Xbox")]
    [SerializeField]
    Sprite _spriteCatchObject_Xbox;
    [SerializeField]
    Sprite _spriteRotate_L_Xbox;
    [SerializeField]
    Sprite _spriteRotate_R_Xbox;
    [SerializeField]
    Sprite _spriteDropButton_Xbox;

    //PS4
    [Header("Sprites PS4")]
    [SerializeField]
    Sprite _spriteCatchObject_PS4;
    [SerializeField]
    Sprite _spriteRotate_L_PS4;
    [SerializeField]
    Sprite _spriteRotate_R_PS4;
    [SerializeField]
    Sprite _spriteDropButton_PS4;
    [SerializeField]float timeAnimations = 0.3f;
    private void Start()
    {
        //_canvasCatchObject.SetActive(false);
        //_canvasRotateObject.SetActive(false);
    }
    private void Update()
    {
        
        if (PickUpObjects.CanCatchObject() && PickUpObjects.IsRotableObject()) // SI se puede pillar el objeto y rotarlo
        {
            AnimationScaleActiveButtonCatch();

            AnimationMoveUpButtonsRotate();
        }
        if(!PickUpObjects.CanCatchObject() && PickUpObjects.IsRotableObject()) //NO se puede pillar el objeto pero SI rotarlo
        {
            AnimationScaleDisableButtonCatch();

            AnimationMoveUpButtonsRotate();
        }
        if(PickUpObjects.CanCatchObject() && !PickUpObjects.IsRotableObject()) //SI se puede pillar el objeto pero NO rotarlo
        {
            AnimationScaleActiveButtonCatch();

            AnimationMoveDownButtonsRotate();
        }
        if (!PickUpObjects.CanCatchObject() && !PickUpObjects.IsRotableObject())
        {
            AnimationScaleDisableButtonCatch();

            AnimationMoveDownButtonsRotate();
        }
        //Cuando el objeto esta pillado
        if (PickUpObjects.IsCatchedObject())
        {
            Sequence _sequence = DOTween.Sequence();
            _sequence.Append(_rectTransformButtonCatchObject.DOScale(new Vector2(0, 0), timeAnimations));
            _sequence.Append(_rectTransformDropButton.DOAnchorPosY(0, timeAnimations));
            AnimationMoveDownButtonsRotate();
            AnimationScaleDisableButtonCatch();

            //AnimationMoveUpDropButton();

        }
        else
        {
            AnimationMoveDownDropButton();
        }
        

    }
    void AnimationMoveUpButtonsRotate()
    {
        foreach (RectTransform r in _rectTransformsButtonsRotate)
        {
            r.DOAnchorPosY(0, timeAnimations);
        }
    }
    void AnimationMoveDownButtonsRotate()
    {
        foreach (RectTransform r in _rectTransformsButtonsRotate)
        {
            r.DOAnchorPosY(-125, timeAnimations);
        }
    }

    void AnimationScaleActiveButtonCatch()
    {
        _rectTransformButtonCatchObject.DOScale(new Vector2(1,1), timeAnimations);
    }
    void AnimationScaleDisableButtonCatch()
    {
        _rectTransformButtonCatchObject.DOScale(new Vector2(0, 0), timeAnimations);
    }

    void AnimationMoveUpDropButton()
    {
        _rectTransformDropButton.DOAnchorPosY(0, timeAnimations);
    }
    void AnimationMoveDownDropButton()
    {
        _rectTransformDropButton.DOAnchorPosY(-125, timeAnimations);
    }
    public void ChangeUI()
    {
        switch (InputManager.controlsState)
        {
            case InputManager.ControlsState.KeyBoard:
                UIKeyboard();
                break;
            case InputManager.ControlsState.Xbox:
                UIXbox();
                break;
            case InputManager.ControlsState.PS4:
                UIPS4();
                break;
        }
    }
    void UIKeyboard()
    {
        _imageCatchObject.sprite = _spriteCatchObject_Keyboard;

    }
    void UIXbox() 
    {
        _imageCatchObject.sprite = _spriteCatchObject_Xbox;
        //Rotate Buttons
        _imageRotateObject_L.sprite = _spriteRotate_L_Xbox;
        _imageRotateObject_R.sprite = _spriteRotate_R_Xbox;
        //Drop Buttons
        _imageDrop.sprite = _spriteDropButton_Xbox;

    }
    void UIPS4()
    {
        _imageCatchObject.sprite = _spriteCatchObject_PS4;
        //Rotate buttons
        _imageRotateObject_L.sprite = _spriteRotate_L_PS4;
        _imageRotateObject_R.sprite = _spriteRotate_R_PS4;
        //Drop buttons
        _imageDrop.sprite = _spriteDropButton_PS4;
    }


}
