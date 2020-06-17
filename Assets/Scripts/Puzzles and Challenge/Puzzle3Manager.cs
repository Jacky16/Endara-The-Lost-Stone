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
    
    //Cajas destruibles
    [Header("Box Componentes")]
    [SerializeField]
    GameObject destructibleBox;
    [SerializeField]
    Transform[] positionBoxes;
    bool isDestroyed_Box1;
    bool isDestroyed_Box2;
    bool isDestroyed_Box3;
    [SerializeField]
    CofreManager[] cofreManagers;

    private void Awake()
    {
        rocksPuzzle3 = RocksCanMove.GetComponentsInChildren<RockPuzzle3>();
    }
    private void Update()
    {
        ChangeSprite();
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
            SpawnBoxes();
            CloseAllCofres();
            isDestroyed_Box1 = false;
            isDestroyed_Box2 = false;
            isDestroyed_Box3 = false;
            playerTransform.position = _spawnPosition.position;
            foreach (RockPuzzle3 rp3 in rocksPuzzle3)
            {
                rp3.ResetPosition();
            }
            animFade.SetTrigger("DeadCaida_End");

        }
    }
    void CloseAllCofres()
    {
        foreach(CofreManager cm in cofreManagers)
        {
            cm.Close();
        }
    }
    void SpawnBoxes()
    {
        if (isDestroyed_Box1)
        {
            GameObject go = Instantiate(destructibleBox, positionBoxes[0].position, positionBoxes[0].rotation);
            go.transform.localScale = new Vector3(1.368012f, 1.368012f, 1.368012f);
        }
        if (isDestroyed_Box2)
        {
            GameObject go = Instantiate(destructibleBox, positionBoxes[1].position, positionBoxes[1].rotation);
            go.transform.localScale = new Vector3(1.368012f, 1.368012f, 1.368012f);
        }
        if (isDestroyed_Box3)
        {
            GameObject go = Instantiate(destructibleBox, positionBoxes[2].position, positionBoxes[2].rotation);
            go.transform.localScale = new Vector3(1.368012f, 1.368012f, 1.368012f);
        }
    }
    public void Box1Destroyed()
    {
        isDestroyed_Box1 = true;
    }
    public void Box2Destroyed()
    {
        isDestroyed_Box2 = true;
    }
    public void Box3Destroyed()
    {
        isDestroyed_Box3 = true;
    }
}
