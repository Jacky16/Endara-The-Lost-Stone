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
    public void RestAttempBoss()
    {
        StartCoroutine(RestAttempBossCoroutine());
        if(_attemptLifeBoss <= 0) // Cuando este abajo de todo el boss se podra pegarle para que reciba impactos del player
        {
            canHitMe = true;
        }
    }
    IEnumerator RestAttempBossCoroutine() // Animacion camara cuando le quitas vida al Boss
    {
        _virtualCamera.Priority = 10;
        yield return new WaitForSeconds(1);
        transform.DOMoveY(transform.position.y - 3, 1);
        _attemptLifeBoss--;
        player.RespawnToWaypoint();
        yield return new WaitForSeconds(2f);
        _virtualCamera.Priority = 0;

    }
}
