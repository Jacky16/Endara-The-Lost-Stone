using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CofreManager : MonoBehaviour
{
    Animator anim;
    [SerializeField] Concept[] concepts;
    [SerializeField] GameObject canvasCofre;
    [SerializeField] GameObject canvasConcept;
    [Header("Componentes Canvas Concept")]
    [SerializeField] Image imageConcept;
    [SerializeField] TextMeshProUGUI textConcept;
    bool isInCanvas;
    [Header("Booleanos sprites")]
    public static bool fluorDarkMode;
    public static bool fluorNightMode;
    [SerializeField]List<Concept> listConcpets = new List<Concept>();
    private void Start()
    {
        anim = GetComponent<Animator>();
        canvasConcept.SetActive(false);
        canvasCofre.SetActive(false);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //if (InputManager.playerInputs.Player_Keyboard.CatchObject.triggered || InputManager.playerInputs.Player_GamepadXbox.X.triggered && !isInCanvas)
            //{
            //    anim.SetTrigger("Open");
            //}
            canvasCofre.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canvasCofre.SetActive(false);

        }
    }
    void ActivateCanvasConcept()
    {
        isInCanvas = true;
        canvasConcept.SetActive(true);

        PlayerMovement.canMove = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        //Logica del concept para que aparezca
        int numberRandom = Random.Range(0, concepts.Length);
        if(!listConcpets.Contains(concepts[numberRandom]) || listConcpets == null)
        {
            listConcpets.Add(concepts[numberRandom]);

        }
        imageConcept.sprite = concepts[numberRandom].spriteConcept;
        textConcept.text ="You've got " + concepts[numberRandom].nameConcept;
 
    }
    public void DisableCanvasConcept()
    {
        canvasConcept.SetActive(false);
        isInCanvas = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        PlayerMovement.canMove = true;

    }
}
