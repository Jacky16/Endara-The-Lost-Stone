using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using DG.Tweening;
using Cinemachine;
using UnityEngine.Playables;

public class BossManager : MonoBehaviour
{
    [SerializeField]
    int _attemptLifeBoss = 3;
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
    PlayableDirector playableDirector_DeadAnimation;

    [SerializeField]
    Animator animBoss;

    [Header("Reset trono")]
    [SerializeField]
    Transform transformSpawnTrono;
    [SerializeField]
    GameObject tronoPrefab;

    //Music cinematic dead
    MusicFader musicFader;
    AudioSource audioSource;

    private void Awake()
    {
        musicFader = GetComponent<MusicFader>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _virtualCamera.Priority = 0;
        SetCanOpenChallenge_1(true);
        SetCanOpenChallenge_2(false);
        SetCanOpenChallenge_3(false);
        playableDirector_DeadAnimation.Stop();
    }
    public void SubstractAttempBoss(Transform pos)
    {
        StartCoroutine(RestAttempBossCoroutine(pos));     
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
        Destroy(transform.Find("Trono_Piedras"));
        Instantiate(tronoPrefab, transformSpawnTrono.position, Quaternion.identity,transform);
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

    //Se ejecuta cada vez que te pasas un reto
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
            Invoke("PlayDeadAnimation", 5);
        }
        animBoss.SetTrigger("Angry_1");
    }
    void PlayDeadAnimation()
    {
        playableDirector_DeadAnimation.Play();
        musicFader.FadeInMusic();
        Invoke("StopMusicCinematic", 25);
        
    }
    void StopMusicCinematic()
    {
        audioSource.DOFade(0, 2);
    }
   
    
}
