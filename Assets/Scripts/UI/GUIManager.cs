using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GUIManager : MonoBehaviour
{
    public EventSystem eventSystem;
    public GameObject firstSelected;
    private void OnEnable()
    {
        eventSystem.SetSelectedGameObject(firstSelected);
    }
    

}
