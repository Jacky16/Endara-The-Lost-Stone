﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ExitDoor : MonoBehaviour
{
    public UnityEvent OnChallengeComplete;
    [SerializeField]
    Enterchallenge enterchallenge;

    [SerializeField]
    BossManager bossManager;

    [SerializeField]
    TimeManager _timeManager;

    [Header("Posicion de la puerta del Reto")]
    [SerializeField]
    Transform _positionDoorChallenge;

    void ExitChallenge()
    {
        //El player no puedo entrar otra vez a este reto si lo ha superado
        enterchallenge.CanEnter(false);
        //Restar una vida al boss y sacar al player del reto
        bossManager.SubstractAttempBoss(_positionDoorChallenge);
        //Parar la cuenta atras
        _timeManager.SetCanSubstractTime(false);
        //Que no puedas entrar en ningun reto
        bossManager.SetCanOpenChallenge_1(false);
        bossManager.SetCanOpenChallenge_2(false);
        bossManager.SetCanOpenChallenge_3(false);
        //Haces una animacion del boss
        bossManager.DoAnimationBoss(3);
        PlayerMovement.canMove = false;
        OnChallengeComplete.Invoke();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ExitChallenge();
        }
    }
}
