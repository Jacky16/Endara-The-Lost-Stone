using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;
using DG.Tweening;


public class Enterchallenge : MonoBehaviour
{
    [SerializeField]
    enum Challenge { First,Second,Third};

    [SerializeField]
    Challenge challenge;

    [SerializeField]
    Transform _positionInChallenge;

    bool canEnter = true;

    [SerializeField]
    TextMeshProUGUI textMeshPro;

    [SerializeField]
    TimeManager _timeManager;

    [SerializeField]
    Animator anim;

    [SerializeField]
    Transform _pivotDoor;

    [Header("Manager Challenges")]
    [SerializeField]
    ZonaSaltosManager zonaSaltosManager; //Third Challenge
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && canEnter || (other.CompareTag("Player") && PlayerMovement.IsModeGod()))
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
                zonaSaltosManager.Invoke("ActivateGravityPlattforms", 4);
                break;
        }
        PlayerMovement.canMove = false;
        _pivotDoor.DOLocalRotate(new Vector3(0, -90, 0), 1);
        anim.SetTrigger("Start");

        yield return new WaitForSeconds(1.3f);

        //Mover al player a su respectivo reto
        other.transform.DOMove(_positionInChallenge.position, .2f);
        _pivotDoor.DOLocalRotate(new Vector3(0, 0, 0), 1);

        other.transform.localRotation = _positionInChallenge.localRotation;
       
        //Asignar donde reaparecerá una vez conseguido el reto
        other.GetComponent<PlayerMovement>().SetRespawn(_positionInChallenge);

        yield return new WaitForSeconds(1.5f);

        anim.SetTrigger("End");
        PlayerMovement.canMove = true;

        yield return new WaitForSeconds(1);

        //Activar la cuenta atras
        _timeManager.SetCanSubstractTime(true);

    }  
}
