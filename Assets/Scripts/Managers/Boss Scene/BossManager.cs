using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using DG.Tweening;
using Cinemachine;
using UnityEngine.Playables;

public class BossManager : MonoBehaviour
{
    float _lifeBoss;
    bool canHitMe;
    [SerializeField]
    int _attemptLifeBoss = 4;
    [SerializeField]
    CinemachineVirtualCamera _virtualCamera;
    [SerializeField]
    PlayerMovement player;

    [Header("Enter Challenges")]
    [SerializeField]
    Enterchallenge enterchallenge_1;
    [SerializeField]
    Enterchallenge enterchallenge_2;
    [SerializeField]
    Enterchallenge enterchallenge_3;
    private void Start()
    {
        _virtualCamera.Priority = 0;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        ResetChallenges();
        
    }
    public void SubstractAttempBoss(Transform pos)
    {
        StartCoroutine(RestAttempBossCoroutine(pos));
        if(_attemptLifeBoss <= 0) // Cuando este abajo de todo el boss se podra pegarle para que reciba impactos del player
        {
            canHitMe = true;
        }
    }
    IEnumerator RestAttempBossCoroutine(Transform posDoorChallange) // Animacion camara cuando le quitas vida al Boss y mover al player a la zona del boss
    {
        _virtualCamera.Priority = 10;

        yield return new WaitForSeconds(1);

        transform.DOMoveY(transform.position.y - 1, 1);
        _attemptLifeBoss--;
        //Asigno la posicion de la puerta del reto en el que estaba
        player.SetRespawn(posDoorChallange);
        player.RespawnToWaypoint();

        yield return new WaitForSeconds(2f);

        _virtualCamera.Priority = 0;
    }
    public void ResetChallenges()
    {
        SetCanOpenChallenge_1(true);
        SetCanOpenChallenge_2(false);
        SetCanOpenChallenge_3(false);
    }
    public void SetCanOpenChallenge_1(bool b)
    {
        enterchallenge_1.CanEnter(b);
    } 
    public void SetCanOpenChallenge_2(bool b)
    {
        enterchallenge_2.CanEnter(b);
    }
    public void SetCanOpenChallenge_3(bool b)
    {
        enterchallenge_3.CanEnter(b);
    }
}
