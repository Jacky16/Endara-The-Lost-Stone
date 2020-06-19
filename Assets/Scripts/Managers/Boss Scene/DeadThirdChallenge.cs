using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadThirdChallenge : MonoBehaviour
{
    [SerializeField]
    TimeManager _timeManager;

    [SerializeField]
    Animator _animFade;

    ZonaSaltosManager _zonaSaltosManager;

    [SerializeField]
    float _timeToSubstract = 50;

    [SerializeField]
    GameObject _gameObjectKey;
    
    [SerializeField]
    GameObject _gameObjectExitDoor; 
    [SerializeField]
    GameObject _gameObjectCurrentWall;
    private void Start()
    {
        _zonaSaltosManager = GetComponentInParent<ZonaSaltosManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            StartCoroutine(DeadPlayer(other));
        }
    }
    IEnumerator DeadPlayer(Collider other)
    {
        _gameObjectExitDoor.SetActive(false);
        _gameObjectCurrentWall.SetActive(true);
        _gameObjectKey.SetActive(true);
        PlayerMovement.canMove = false;
        _animFade.SetTrigger("DeadCaida_Start");
        _timeManager.SubstractTime(_timeToSubstract);

        yield return new WaitForSeconds(1);

        _zonaSaltosManager.RestartPlattformsPositions();
        other.GetComponent<PlayerMovement>().SetRespawn(_zonaSaltosManager.RespawnPlayer()); //Asignar el respawn del 3r reto para cuando muere
        other.GetComponent<PlayerMovement>().RespawnToWaypoint();

        yield return new WaitForSeconds(1);

        _animFade.SetTrigger("DeadCaida_End");
        PlayerMovement.canMove = true;

    }
}
