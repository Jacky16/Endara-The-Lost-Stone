using DG.Tweening;
using UnityEngine;

public class PickUpObjects : MonoBehaviour
{
    [HideInInspector] public GameObject objectToPickup;
    [HideInInspector] public GameObject PickedObject;
    Transform _interactionZone;
    static bool _canCatchObject;
    static bool _isCatched;
    static bool _isRotable;
    static bool _canThrowObject;
    static float massPickedObject;
    Animator animPlayer;
    UIManager uIManager;
    private void Awake()
    {
        _interactionZone = GameObject.FindGameObjectWithTag("TransformObjectPickUp").GetComponent<Transform>();
        uIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        animPlayer = GetComponent<Animator>();
    }
  
    public void CatchObjectSystem()
    {
        if (CanCatchObject()) //Pillar el objeto
        {
            uIManager.AnimationMoveUpDropButton();
            uIManager.AnimationMoveDownButtonsRotate();
            uIManager.AnimationScaleDisableButtonCatch();

            animPlayer.SetTrigger("PickUp");
        }
        else //Soltar el objeto

        {
            if (PickedObject != null)
            {
                uIManager.AnimationMoveDownDropButton();
                animPlayer.SetTrigger("PickUp");
                _isCatched = false;
                _canCatchObject = true;
                PickedObject.GetComponent<ObjetoPickeable>().isPickeable = true;
                PickedObject.transform.SetParent(null);
                _canThrowObject = false;
                PickedObject.GetComponent<Rigidbody>().useGravity = true;
                PickedObject.GetComponent<Rigidbody>().isKinematic = false;
                PickedObject.GetComponent<BoxCollider>().isTrigger = false;
                PickedObject.GetComponent<Rigidbody>().AddForce(Vector3.down * 4);
                PickedObject = null;
                animPlayer.SetBool("isCatched", PickedObject);
            }
        }
    }

    public void EventCatchObjectSystem() // Se ejecuta en la animacion de catch
    {
        if (objectToPickup != null && objectToPickup.GetComponent<ObjetoPickeable>().isPickeable == true && PickedObject == null)
        {
            //Pillar el objeto 
            _isCatched = true;
            _canCatchObject = false;
            _canThrowObject = true;
            PickedObject = objectToPickup;
            PickedObject.GetComponent<ObjetoPickeable>().isPickeable = false;
            PickedObject.transform.SetParent(_interactionZone);
            PickedObject.transform.position = _interactionZone.transform.position;
            PickedObject.GetComponent<Rigidbody>().useGravity = false;
            PickedObject.GetComponent<Rigidbody>().isKinematic = true;
            PickedObject.GetComponent<BoxCollider>().isTrigger = true;
            massPickedObject = PickedObject.GetComponent<Rigidbody>().mass;
            animPlayer.SetBool("isCatched", PickedObject);

        }

    }
    
    public bool CanThrow()
    {
        if (PickedObject.GetComponent<ObjetoPickeable>().isPickeable == true)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    public void SetCanCatch(bool b)
    {
        _canCatchObject = b;
    }
    public void SetCanRotate(bool b)
    {
        _isRotable = b;
    }
    public void Rotate_R(float grades)
    {
        if (objectToPickup != null || PickedObject != null)
        {
            if (objectToPickup.tag == "Cubo" && _isRotable)
            {
                objectToPickup.transform.DOLocalRotate(new Vector3(0, grades, 0), 0.2f, RotateMode.LocalAxisAdd);
            }

            if (PickedObject.tag == "Cubo" && _isRotable)
            {
                PickedObject.transform.DOLocalRotate(new Vector3(0, grades, 0), 0.2f, RotateMode.LocalAxisAdd);
            }
        }
        
    }
    public void Rotate_L(float grades)
    {
        if (objectToPickup != null || PickedObject != null)
        {
            if (objectToPickup.tag == "Cubo" && _isRotable)
            {
                objectToPickup.transform.DOLocalRotate(new Vector3(0, -grades, 0), 0.2f, RotateMode.LocalAxisAdd);
            }
           
            if (PickedObject.tag == "Cubo" && _isRotable)
            {
                PickedObject.transform.DOLocalRotate(new Vector3(0, -grades, 0), 0.2f, RotateMode.LocalAxisAdd);
            }
        }
        

    }
    public static bool CanCatchObject()
    {
        return _canCatchObject;
    }
    public static bool IsCatchedObject()
    {
        return _isCatched;
    }
    public static bool IsRotableObject()
    {
        return _isRotable;
    }
    public static bool CanThrowObject()
    {
        return _canThrowObject;
    }
    public static float MassObjectPicked()
    {
        return massPickedObject;
    }
}