using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GodManager : MonoBehaviour
{
    PlayerMovement playerMovement;
    [SerializeField] GameObject canvasModeGod;
    public float unitsGravityModeGod;
    public TextMeshProUGUI textSpaceUp;
    public TextMeshProUGUI textSpaceDown;
    public TMP_InputField inputFieldUnits;

    private void Start()
    {
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
        unitsGravityModeGod = 5;

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F10))
        {
           playerMovement.isGod = !playerMovement.isGod;
        }
        if (playerMovement.isGod)
        {
            canvasModeGod.SetActive(true);
            textSpaceUp.text = "Space = Up " + UnitsToJumpInModeGod().ToString() + " Units";
            textSpaceDown.text = "Space = Down " + UnitsToJumpInModeGod().ToString() + " Units";
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            canvasModeGod.SetActive(false);
            //Cursor.visible = false;
            //Cursor.lockState = CursorLockMode.Locked;
        }
        
    }
    public float UnitsToJumpInModeGod()
    {
        return unitsGravityModeGod;
    }
    public void AssingInputField()
    {
        unitsGravityModeGod = float.Parse(inputFieldUnits.text);
        inputFieldUnits.text = null;
    }
    public void Sum2Units()
    {
        unitsGravityModeGod += 2;
    }
    public void Rest2Units()
    {
        unitsGravityModeGod -= 2;
    }
    


}
