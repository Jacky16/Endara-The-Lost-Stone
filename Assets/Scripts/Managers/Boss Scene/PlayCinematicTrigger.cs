using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayCinematicTrigger : MonoBehaviour
{
    public UnityEvent OnTriggerEnterCollider;
    bool cinematicIsPlayed;
    [SerializeField]
    AudioSource musicGameplay;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !cinematicIsPlayed)
        {
            musicGameplay.DOFade(0,1).OnComplete(() => OnTriggerEnterCollider.Invoke());
            cinematicIsPlayed = true;
        }
    }
}
