using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;

public class Enterchallenge : MonoBehaviour
{
    [SerializeField]
    enum Challenge { First,Second,Third};
    [SerializeField]
    Challenge challenge;
    [SerializeField]
    Transform _positionInChallenge;
    [SerializeField]
    bool canEnter = true;
    [SerializeField]
    TextMeshProUGUI textMeshPro;
   

    [SerializeField]
    Animator anim;
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           StartCoroutine(MovePlayerToChallenge(other));
            
            
        }
    }
    public void CanEnter(bool b)
    {
        canEnter = b;
    }
    IEnumerator MovePlayerToChallenge(Collider other)
    {
        switch (challenge)
        {
            case Challenge.First:
                textMeshPro.text = "First Challenge";
                break;
            case Challenge.Second:
                textMeshPro.text = "Second Challenge";
                break;
            case Challenge.Third:
                textMeshPro.text = "Third Challenge";
                break;
        }
        anim.SetTrigger("Start");
        yield return new WaitForSeconds(1.3f);
      
        other.transform.position = _positionInChallenge.position;
        other.transform.localRotation = _positionInChallenge.localRotation;
        yield return new WaitForSeconds(1.5f);
        anim.SetTrigger("End");
        

    }
    //public void CheckSolution()
    //{
    //    switch (challenge)
    //    {
    //        case Challenge.First:

    //            break;
    //    }
    //}
}
