using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GUIManager : MonoBehaviour
{
    public EventSystem Es;
    public GameObject selectThisFirst;

    //private void Update()
    //{
    //    if(Es.currentSelectedGameObject != storeSelected)
    //    {
    //        if(Es.currentSelectedGameObject == null)
    //        {
    //            Es.SetSelectedGameObject(storeSelected);
    //        }
    //        else
    //        {
    //            storeSelected = Es.currentSelectedGameObject;
    //        }
    //    }
    //}

    private void OnEnable()
    {
        Es.SetSelectedGameObject(selectThisFirst);
    }

}
