using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleObjectsManager : MonoBehaviour
{
    public GameObject [] invisibleObjects;
    void Start()
    {
        foreach (GameObject wi in invisibleObjects)
        {
            wi.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
   

    private void OnTriggerEnter(Collider other)
    {
        
            StartCoroutine(ivisibleObject());
            Debug.Log("Me he chocado con el player");
        
    }

    IEnumerator ivisibleObject()
    {
        this.gameObject.GetComponent<Renderer>().enabled = false;
        foreach (GameObject wi in invisibleObjects)
        {
            wi.SetActive(true);
        }
        yield return new WaitForSeconds(2f);
        foreach (GameObject wi in invisibleObjects)
        {
            wi.SetActive(false);
        }
        this.gameObject.GetComponent<Renderer>().enabled = true;

    }
}
