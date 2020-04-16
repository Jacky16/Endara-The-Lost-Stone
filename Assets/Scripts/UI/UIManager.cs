using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    [Header("Referencias a scripts")]
    //[SerializeField]
    //Palanca _palanca;
    static bool _playerInCofre;
    static bool _playerInPalanca;

    //RectTransform buttons------------------------------

    [Header("RectTransform Catch Object")]
    [SerializeField]
    RectTransform _rectTransformButtonCatchObject;
    [Header("RectTransforms Rotate Objects")]
    [SerializeField]
    RectTransform[] _rectTransformsButtonsRotate;
    [Header("RectTransform Drop Object")]
    [SerializeField]
    RectTransform _rectTransformDropButton;
    [Header("RectTransform Use Object")]
    [SerializeField]
    RectTransform _rectTransformButtonUseObject;
    [Header("RectTransform Open Object")]
    [SerializeField]
    RectTransform _rectTransformButtonOpenObject;
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

    //Image Drop Object
    [Header("Image Drop Object")]
    [SerializeField]
    Image _imageDrop;

    //Image Palanca Use
    [Header("Image Palanca Use")]
    [SerializeField]
    Image _imageUseButton;
    //Image Open
    [Header("Image Open")]
    [SerializeField]
    Image _imageOpen;

    //Image

    //Sprites------------------------------

    //Keyboard/Mouse--------------
    [Header("Sprites Keyboard")]
    [SerializeField]
    Sprite _spriteCatchObject_Keyboard;
    [SerializeField]
    Sprite _spriteRotate_Keyboard_L;
    [SerializeField]
    Sprite _spriteRotate_Keyboard_R;
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
        ChangeUI();
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

        //Desactiv
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

        //Interaccion con la palanca del 1r puzzle
        if (_playerInPalanca) //ToDo: cambiar la variable bool
        {
            AnimationScaleActiveButtonUse();
        }
        else
        {
            AnimationScaleDisableButtonUse();
        }
        //Interaccion con los cofres
        if (_playerInCofre)
        {
            AnimationScaleActiveButtonOpen();
        }
        else
        {
            AnimationScaleDisableButtonOpen();
        }
    }
    
    #region Animations
    //Animaciones botones de rotar
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
    //Animaciones de Abrir el objeto
    void AnimationScaleActiveButtonOpen()
    {
        _rectTransformButtonOpenObject.DOScale(new Vector2(1, 1), timeAnimations);
    }
    void AnimationScaleDisableButtonOpen()
    {
        _rectTransformButtonOpenObject.DOScale(new Vector2(0, 0), timeAnimations);
    }
    #endregion
    public void ChangeUI()
    {
        print(InputManager.controlsState);
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
        //Catch Object
        _imageCatchObject.sprite = _spriteCatchObject_Keyboard;
        //Rotate Buttons
        _imageRotateObject_L.sprite = _spriteRotate_Keyboard_L;
        _imageRotateObject_R.sprite = _spriteRotate_Keyboard_R;
        //Drop Buttons
        _imageDrop.sprite = _spriteInteractionButton_Keyboard;
        //Use button
        _imageUseButton.sprite = _spriteCatchObject_Keyboard;
        //Open
        _imageOpen.sprite = _spriteCatchObject_Keyboard;
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
        //Open
        _imageOpen.sprite = _spriteCatchObject_Xbox;
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
        //Open
        _imageOpen.sprite = _spriteCatchObject_PS4;
    }
    public static void SetPlayerPalanca(bool b)
    {
        _playerInPalanca = b;
    }
    public static void SetPlayerCofre(bool b)
    {
        _playerInCofre = b;
    }
}
