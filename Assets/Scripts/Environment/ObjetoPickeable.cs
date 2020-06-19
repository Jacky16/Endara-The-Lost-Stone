using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
[RequireComponent(typeof(Rigidbody))]

public class ObjetoPickeable : MonoBehaviour
{
    public bool isPickeable;
    public bool isRoteable;
    [SerializeField]
    bool emitParticleSmoke;
    UIManager uIManager;
    [SerializeField]
    ParticleSystem particleSmoke;

    private void Awake()
    {
        uIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerInteraction")
        {
            other.GetComponentInParent<PickUpObjects>().objectToPickup = this.gameObject;
            other.GetComponentInParent<PickUpObjects>().SetCanCatch(isPickeable);
            other.GetComponentInParent<PickUpObjects>().SetCanRotate(isRoteable);

            //Controlador de las animaciones de la UI
            if (isPickeable && isRoteable)
            {
                uIManager.AnimationScaleActiveButtonCatch();

                uIManager.AnimationMoveUpButtonsRotate();
            }
            if(!isPickeable && isRoteable)
            {
                uIManager.AnimationScaleDisableButtonCatch();

                uIManager.AnimationMoveUpButtonsRotate();
            }
            if (isPickeable && !isRoteable)
            {
                uIManager.AnimationScaleActiveButtonCatch();

                uIManager.AnimationMoveDownButtonsRotate();
            }
        }  
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "PlayerInteraction")
        {
            other.GetComponentInParent<PickUpObjects>().objectToPickup = null;
            other.GetComponentInParent<PickUpObjects>().SetCanCatch(false);
            other.GetComponentInParent<PickUpObjects>().SetCanRotate(!isRoteable && false);

            //Controlador de las animaciones de la UI
            if (isPickeable && isRoteable)
            {
                uIManager.AnimationScaleDisableButtonCatch();

                uIManager.AnimationMoveDownButtonsRotate();
            }
            if (!isPickeable && isRoteable)
            {
                uIManager.AnimationScaleDisableButtonCatch();

                uIManager.AnimationMoveDownButtonsRotate();
            }
            if (isPickeable && !isRoteable)
            {
                uIManager.AnimationScaleDisableButtonCatch();

                uIManager.AnimationMoveDownButtonsRotate();
            }
            
            //uIManager.AnimationMoveDownDropButton();
        }
        

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (emitParticleSmoke)
        {
            particleSmoke.Play();
        }
        
    }
}