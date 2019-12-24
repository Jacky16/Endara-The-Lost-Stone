using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputManager : MonoBehaviour
{
    public PlayerMovement player;
    [SerializeField] PickUpObjects pickUpsObjects;
    public InputAction inputKeyBoard;
    public InputAction inputXboxController;
    [SerializeField] KeyCode keyCodeCatchObject = KeyCode.F;
    [SerializeField] KeyCode keyCodeThrowObject = KeyCode.Mouse0;
    bool jostickXboxPressed;
    Vector2 vectorAxis;

    private void Update() {
        vectorAxis = inputXboxController.ReadValue<Vector2>();
        Debug.Log(vectorAxis);
        player.Axis(H(),V());
        MeleAttack();
        //CatchObject();
        //DropObject();
        //ThrowObject();
    } 
    //Movimiento horizontal y vertical
    public float H(){
        return vectorAxis.x;
    }
    public float V(){
        return vectorAxis.y;
    }
    public void OnEnable()
    {
        inputKeyBoard.Enable();
        inputXboxController.performed += x => jostickXboxPressed = true;

    }
    public void OnDisable()
    {
        inputKeyBoard.Disable();
    }

    public void MeleAttack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            player.MeleAtack();
        }
    }


    //public void CatchObject()
    //{
    //    if (Input.GetKeyDown(keyCodeCatchObject))
    //    {
    //        pickUpsObjects.CatchObjectManager();
        

    //    }
    //}
    //public void DropObject()
    //{
    //    if (Input.GetKeyDown(keyCodeCatchObject))
    //        pickUpsObjects.DropObjectManager();
    //}
    //public void ThrowObject()
    //{
    //    if (Input.GetKeyDown(keyCodeThrowObject))
    //    {
    //        pickUpsObjects.ThrowObjectsManager();
    //    }
    //}
    
    
}
