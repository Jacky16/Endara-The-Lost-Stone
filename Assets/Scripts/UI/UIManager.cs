using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    [Header("Referencias a scripts")]
    [SerializeField]
    Palanca _palanca;

    //RectTransform buttons------------------------------
    [Header("RectTransform Buttons")]
    [SerializeField]
    RectTransform _rectTransformButtonCatchObject;
    [SerializeField]
    RectTransform[] _rectTransformsButtonsRotate;
    [SerializeField]
    RectTransform _rectTransformsButtonsRotate_Keyboard;
    [SerializeField]
    RectTransform _rectTransformDropButton;
    [SerializeField]
    RectTransform _rectTransformButtonUseObject;
    //Images components------------------------------

    //Image Catcht Object 
    [Header("Image Catcht Object")]
    [SerializeField]
    Image _imageCatchObject;

    //Image Rotate Object
    [Header("Image Rotate Objects")]
    [SerializeField]
    Image _imageRotateObject_L;
    [SerializeField]
    Image _imageRotateObject_R;
    [SerializeField]
    Image _imageRotate_R_Keyboard;
    //Image Drop Object
    [Header("Image Drop Object")]
    [SerializeField]
    Image _imageDrop;

    //Image Palanca Use
    [Header("Image Palanca Use")]
    [SerializeField]
    Image _imageUseButton;

    //Sprites------------------------------

    //Keyboard/Mouse--------------
    [Header("Sprites Keyboard")]
    [SerializeField]
    Sprite _spriteCatchObject_Keyboard;
    [SerializeField]
    Sprite _spriteRotate_Keyboard;
    [SerializeField]
    Sprite _spriteInteractionButton_Keyboard;

    //Xbox--------------
    [Header("Sprites Xbox")]
    [SerializeField]
    Sprite _spriteCatchObject_Xbox;
    [SerializeField]
    Sprite _spriteRotate_L_Xbox;
    [SerializeField]
    Sprite _spriteRotate_R_Xbox;
    [SerializeField]
    Sprite _spriteInteractionButton_Xbox;

    //PS4--------------
    [Header("Sprites PS4")]
    [SerializeField]
    Sprite _spriteCatchObject_PS4;
    [SerializeField]
    Sprite _spriteRotate_L_PS4;
    [SerializeField]
    Sprite _spriteRotate_R_PS4;
    [SerializeField]
    Sprite _spriteInteractionButton_PS4;
    [SerializeField]float timeAnimations = 0.3f;
   
    private void Update()
    {
        LogicButtonsUI();
    }
    void LogicButtonsUI()
    {

        if (PickUpObjects.CanCatchObject() && PickUpObjects.IsRotableObject()) // SI se puede pillar el objeto y rotarlo
        {
            AnimationScaleActiveButtonCatch();

            AnimationMoveUpButtonsRotate();
        }
        if (!PickUpObjects.CanCatchObject() && PickUpObjects.IsRotableObject()) //NO se puede pillar el objeto pero SI rotarlo
        {
            AnimationScaleDisableButtonCatch();

            AnimationMoveUpButtonsRotate();
        }
        if (PickUpObjects.CanCatchObject() && !PickUpObjects.IsRotableObject()) //SI se puede pillar el objeto pero NO rotarlo
        {
            AnimationScaleActiveButtonCatch();

            AnimationMoveDownButtonsRotate();
        }
        if (!PickUpObjects.CanCatchObject() && !PickUpObjects.IsRotableObject() && !_palanca.PlayerInPalanca())
        {
            AnimationScaleDisableButtonCatch();

            AnimationMoveDownButtonsRotate();

            AnimationScaleDisableButtonUse();

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

        ////Interaccion con la palanca del 1r puzzle

        if (_palanca.PlayerInPalanca())
        {
            AnimationScaleActiveButtonUse();
        }


    }
    #region Animations
    //Animaciones botones de rotar
    void AnimationMoveUpButtonsRotate()
    {
        switch (InputManager.controlsState)
        {
            case InputManager.ControlsState.KeyBoard:
                _rectTransformsButtonsRotate_Keyboard.DOAnchorPosY(0, timeAnimations);
                foreach (RectTransform r in _rectTransformsButtonsRotate)
                {
                    r.DOAnchorPosY(-125, timeAnimations);
                } //Desaparece la UI de gamepad, por si cambias al Teclado y no se solapen
                break;
            case InputManager.ControlsState.Xbox:
                foreach (RectTransform r in _rectTransformsButtonsRotate)
                {
                    r.DOAnchorPosY(0, timeAnimations);
                }
                _rectTransformsButtonsRotate_Keyboard.DOAnchorPosY(-125, timeAnimations); //Desaparece la UI del Keyboard, por si cambias al Gamepad
                break;
            case InputManager.ControlsState.PS4:
                foreach (RectTransform r in _rectTransformsButtonsRotate)
                {
                    r.DOAnchorPosY(0, timeAnimations);
                }
                _rectTransformsButtonsRotate_Keyboard.DOAnchorPosY(-125, timeAnimations); //Desaparece la UI del Keyboard, por si cambias al Gamepad
                break;
        }
    }
    void AnimationMoveDownButtonsRotate()
    {
        switch (InputManager.controlsState)
        {
            case InputManager.ControlsState.KeyBoard:
                _rectTransformsButtonsRotate_Keyboard.DOAnchorPosY(-125, timeAnimations);
                break;
            case InputManager.ControlsState.Xbox:
                foreach (RectTransform r in _rectTransformsButtonsRotate)
                {
                    r.DOAnchorPosY(-125, timeAnimations);
                }
                _rectTransformsButtonsRotate_Keyboard.DOAnchorPosY(-125, timeAnimations);//Desaparece la UI del Keyboard, por si cambias al Gamepad
                break;
            case InputManager.ControlsState.PS4:
                foreach (RectTransform r in _rectTransformsButtonsRotate)
                {
                    r.DOAnchorPosY(-125, timeAnimations);
                }
                _rectTransformsButtonsRotate_Keyboard.DOAnchorPosY(-125, timeAnimations); //Desaparece la UI del Keyboard, por si cambias al Gamepad
                break;
        }
    }

    //Animaciones botones de pillar el objeto
    void AnimationScaleActiveButtonCatch()
    {
        _rectTransformButtonCatchObject.DOScale(new Vector2(1,1), timeAnimations);
    }
    void AnimationScaleDisableButtonCatch()
    {
        _rectTransformButtonCatchObject.DOScale(new Vector2(0, 0), timeAnimations);
    }

    //Animaciones Desactivar botones de usar
    void AnimationScaleDisableButtonUse()
    {
        _rectTransformButtonUseObject.DOScale(new Vector2(0, 0), timeAnimations);
    }
    void AnimationScaleActiveButtonUse()
    {
        _rectTransformButtonUseObject.DOScale(new Vector2(1,1), timeAnimations);
    }

    //Animaciones de dropear el objeto
    void AnimationMoveUpDropButton()
    {
        _rectTransformDropButton.DOAnchorPosY(0, timeAnimations);
    }
    void AnimationMoveDownDropButton()
    {
        _rectTransformDropButton.DOAnchorPosY(-140, timeAnimations);
    }
    #endregion
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
        //Rotate Buttons
        _imageRotateObject_R.sprite = _spriteRotate_Keyboard;
        //Drop Buttons
        _imageDrop.sprite = _spriteInteractionButton_Keyboard;
        //Use button
        _imageUseButton.sprite = _spriteCatchObject_Keyboard;
    }
    void UIXbox() 
    {
        _imageCatchObject.sprite = _spriteCatchObject_Xbox;
        //Rotate Buttons
        _imageRotateObject_L.sprite = _spriteRotate_L_Xbox;
        _imageRotateObject_R.sprite = _spriteRotate_R_Xbox;
        //Drop Buttons
        _imageDrop.sprite = _spriteInteractionButton_Xbox;
        //Use button
        _imageUseButton.sprite = _spriteCatchObject_Xbox;

    }
    void UIPS4()
    {
        _imageCatchObject.sprite = _spriteCatchObject_PS4;
        //Rotate buttons
        _imageRotateObject_L.sprite = _spriteRotate_L_PS4;
        _imageRotateObject_R.sprite = _spriteRotate_R_PS4;
        //Drop buttons
        _imageDrop.sprite = _spriteInteractionButton_PS4;
        //Use button
        _imageUseButton.sprite = _spriteCatchObject_PS4;
    }
}
