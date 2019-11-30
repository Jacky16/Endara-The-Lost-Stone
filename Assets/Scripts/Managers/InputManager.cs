using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public PlayerMovement player;

    private void Update() {
        player.Axis(H(),V());
        
    } 
    //Movimiento horizontal y vertical
    public float H(){
        return Input.GetAxis("Horizontal");

    }
    public float V(){
        return Input.GetAxis("Vertical");
    }
    
    
}
