using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ResetLaberinto : MonoBehaviour
{
    [SerializeField]
    Transform playerTransform;
    [SerializeField]
    Transform spawn;
    [SerializeField]
    Animator animTransition;
    bool playerInside;

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
    public void ResetLaberintoAction(InputAction.CallbackContext ctx)
    {
        if (ctx.started && playerInside) 
        {
            StartCoroutine(ResetLaberintoAnimation());
        }
    }
    private void Update()
    {
        ChangeSprite();
    }
    IEnumerator ResetLaberintoAnimation()
    {
        animTransition.SetTrigger("DeadCaida_Start");
        yield return new WaitForSeconds(1);
        playerTransform.position = spawn.position;
        PlayerMovement.canMove = false;
        yield return new WaitForSeconds(1);
        animTransition.SetTrigger("DeadCaida_End");
        PlayerMovement.canMove = true;
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
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
        }
    }
    
}
