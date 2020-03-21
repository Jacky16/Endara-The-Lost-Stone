using DG.Tweening;
using UnityEngine;

public class PickUpObjects : MonoBehaviour
{
    public GameObject objectToPickup;
    public GameObject PickedObject;
    Transform _interactionZone;
    static bool _canCatchObject;
    static bool _isCatched;
    static bool _isRotable;
    static bool _canThrowObject;
    static float massPickedObject;

    private void Start()
    {
        _interactionZone = GameObject.FindGameObjectWithTag("TransformObjectPickUp").GetComponent<Transform>();
    }
    void Update()
    {
        //if (objectToPickup != null)
        //{
        //    _isCatchObject = true;
        //}
        //else
        //{
        //    _isCatchObject = false;
        //    _canThrowObject = false;
        //}

        //if (PickedObject != null)
        //{
        //    _isCatchObject = false;
        //}
        if (Input.GetMouseButtonDown(0))
        {
            ThrowObject();
        }
        if (_isCatched)
        {
            _canCatchObject = false;
            _isRotable = false;
        }
    }
    public void PillarElObjeto()
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

        }
        else if (PickedObject != null)
        {
            //Soltar el objeto
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

        }
    }
    public void ThrowObject()
    {
        if (_isCatched)
        {
            PickedObject = objectToPickup;
            if (PickedObject)
            {
                PickedObject.GetComponent<BoxCollider>().isTrigger = true;
                PickedObject.GetComponent<Rigidbody>().isKinematic = false;
                PickedObject.transform.SetParent(null);
                _canThrowObject = false;
                PickedObject.GetComponent<Rigidbody>().useGravity = true;
                PickedObject.GetComponent<Rigidbody>().AddForce(this.transform.forward + Camera.main.transform.forward * 50);
                PickedObject.GetComponent<BoxCollider>().isTrigger = false;
                PickedObject.GetComponent<ObjetoPickeable>().isPickeable = true;
                PickedObject = null;
            }         
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
        if (objectToPickup)
        {
            if (objectToPickup.tag == "Cubo" && objectToPickup.GetComponent<ObjetoPickeable>().isRoteable)
            {
                objectToPickup.transform.DOLocalRotate(new Vector3(0, grades, 0), 0.2f, RotateMode.LocalAxisAdd);
            }

            if (PickedObject.tag == "Cubo" && PickedObject.GetComponent<ObjetoPickeable>().isRoteable)
            {
                PickedObject.transform.DOLocalRotate(new Vector3(0, grades, 0), 0.2f, RotateMode.LocalAxisAdd);
            }
        }
        
    }
    public void Rotate_L(float grades)
    {
        if (objectToPickup)
        {
            if (objectToPickup.tag == "Cubo" && objectToPickup.GetComponent<ObjetoPickeable>().isRoteable)
            {
                objectToPickup.transform.DOLocalRotate(new Vector3(0, -grades, 0), 0.2f, RotateMode.LocalAxisAdd);
                _isRotable = true;
            }
            else
            {
                _isRotable = false;
            }
            if (PickedObject.tag == "Cubo" && PickedObject.GetComponent<ObjetoPickeable>().isRoteable)
            {
                PickedObject.transform.DOLocalRotate(new Vector3(0, -grades, 0), 0.2f, RotateMode.LocalAxisAdd);
                _isRotable = true;
            }
            else
            {
                _isRotable = false;
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