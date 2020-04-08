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
    TimeManager _timeManager;

    [SerializeField]
    Animator anim;
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && canEnter)
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
        PlayerMovement.canMove = false;
        anim.SetTrigger("Start");
        yield return new WaitForSeconds(1.3f);

        //Mover al player a su respectivo reto
        other.transform.position = _positionInChallenge.position;
        other.transform.localRotation = _positionInChallenge.localRotation;

        //Asignar donde reaparecerá una vez conseguido el reto
        other.GetComponent<PlayerMovement>().SetRespawn(transform);
        yield return new WaitForSeconds(1.5f);
        anim.SetTrigger("End");
        PlayerMovement.canMove = true;
        yield return new WaitForSeconds(1);
        //Activar la cuenta atras
        _timeManager.SetCanSubstractTime(true);

    }
    
}
