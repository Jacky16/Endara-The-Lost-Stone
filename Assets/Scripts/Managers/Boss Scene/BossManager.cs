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

    [Header("TimeLines")]
    [SerializeField]
    PlayableDirector playableDirector_Reto_1;
    [SerializeField]
    PlayableDirector playableDirector_Reto_2;
    [SerializeField]
    PlayableDirector playableDirector_Reto_3;

    [SerializeField]
    Animator animBoss;
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
    public void DoAnimationBoss(int challenge)
    {
        if(challenge == 1)
        {
            playableDirector_Reto_1.Play();
        }
        if (challenge == 2)
        {
            playableDirector_Reto_2.Play();
        }
        if (challenge == 3)
        {
            playableDirector_Reto_3.Play();
        }
        RandomAnimBoss(Random.Range(1, 4));
    }

    void RandomAnimBoss(int number)
    {
        if(number == 1)
        {
            animBoss.SetTrigger("Angry_1");
        }
        else if(number == 2)
        {
            animBoss.SetTrigger("Angry_2");
        }
        else if(number == 3)
        {
            animBoss.SetTrigger("Angry_3");
        }
        else if(number == 4)
        {
            animBoss.SetTrigger("Angry_4");
        }
    }
}
