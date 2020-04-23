using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Puzzle3Manager : MonoBehaviour
{
    [Header("Rocks Puzzle")]
    [SerializeField]
    GameObject RocksCanMove;

    RockPuzzle3[] rocksPuzzle3;

    [SerializeField]
    SwitchCamera switchCamera;

    [Header("Spawn")]
    [SerializeField]
    Transform playerTransform;

    [SerializeField]
    Transform _spawnPosition;

    //Animator
    [Header("Animator Fade")]
    [SerializeField]
    Animator animFade;

    //UI Components
    [Header("Image Canvas")]
    [SerializeField]
    Image _imageButtonReset;

    [Header("Sprites Button")]
    [SerializeField]
    Sprite _spriteButtonRestet_PC;

    [SerializeField]
    Sprite _spriteButtonRestet_Xbox;

    [SerializeField]
    Sprite _spriteButtonRestet_PS4;

    private void Awake()
    {
        rocksPuzzle3 = RocksCanMove.GetComponentsInChildren<RockPuzzle3>();
    }
    public void ResetPuzzle3(InputAction.CallbackContext inputAction)
    {
        if (inputAction.started)
        {
            if (switchCamera.PlayerIsInside())
            {
                StartCoroutine(ResetPuzzle3Coroutine());
            }
        }   
        
    }
    public void ChangeSprite()
    {
        switch (InputManager.controlsState)
        {
            case InputManager.ControlsState.KeyBoard:
                _imageButtonReset.sprite = _spriteButtonRestet_PC;
                break;
            
            case InputManager.ControlsState.Xbox:
                _imageButtonReset.sprite = _spriteButtonRestet_Xbox;
                break;
            
            case InputManager.ControlsState.PS4:
                _imageButtonReset.sprite = _spriteButtonRestet_PS4;
                break;
        }
    }

    IEnumerator ResetPuzzle3Coroutine()
    {
        if (switchCamera)
        {
            animFade.SetTrigger("DeadCaida_Start");

            yield return new WaitForSeconds(1);

            playerTransform.position = _spawnPosition.position;
            foreach (RockPuzzle3 rp3 in rocksPuzzle3)
            {
                rp3.ResetPosition();
            }
            animFade.SetTrigger("DeadCaida_End");

        }
    }
}
