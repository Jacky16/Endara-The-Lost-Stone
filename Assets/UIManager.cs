using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    [Header("Referencias Scripts")]
    [SerializeField]
    PickUpObjects pickUpObjects;
    [Header("PC")]

    //[Header("Canvas Catch/Rotate Object")]
    //[SerializeField]
    //GameObject canvasCatchObject;
    //[SerializeField]
    //GameObject canvasThrowObject;

    [Header("Xbox")]

    [SerializeField]

    GameObject _canvasCatchObjectXbox;
    [SerializeField]

    RectTransform _recTransformCatchObjectXbox;
    [SerializeField]

    GameObject canvasThrowObjectXbox;

    PlayerGamepadInputs playerInputs = new PlayerGamepadInputs();
    private void Start()
    {
       _canvasCatchObjectXbox.SetActive(true);
        canvasThrowObjectXbox.SetActive(true);
    }
    private void Update()
    {
        if (InputManager.useGamepad)
        {
            if (pickUpObjects.IsCanvasCatchObject())
            {
                // _canvasCatchObjectXbox.SetActive(true);
                _recTransformCatchObjectXbox.DOScale(new Vector3(1, 1, 1), 0.3f);

            }
            else
            {
                _recTransformCatchObjectXbox.DOScale(new Vector3(0, 0, 0), 0.3f);
               
            }
        }
        else
        {

        }

    }
    void DisableCanvasCatchObjectXbox()
    {
        if (playerInputs.Player_GamepadXbox.X.triggered)
        {
            Sequence secuencia = DOTween.Sequence();

            secuencia.Append(_recTransformCatchObjectXbox.DOScale(new Vector3(0, 0, 0), 0.3f)).PrependCallback(ChangeToGray).AppendCallback(ChangeToWhite);
        }
    }
    void ChangeToGray()
    {
        _recTransformCatchObjectXbox.GetComponent<Image>().color = Color.gray;
    }
    void ChangeToWhite()
    {
        _recTransformCatchObjectXbox.GetComponent<Image>().color = Color.white;
    }


}
