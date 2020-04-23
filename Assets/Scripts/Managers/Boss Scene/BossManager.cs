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
    private void Start()
    {
        _virtualCamera.Priority = 0;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
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
}
