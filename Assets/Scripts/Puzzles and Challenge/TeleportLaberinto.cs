using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TeleportLaberinto : MonoBehaviour
{
    public UnityEvent OnChallengeComplete;
    [SerializeField]
    BossManager bossManager;

    [SerializeField]
    Transform spawnPlayer;
    private void OnTriggerEnter(Collider other)
    {
        bossManager.SubstractAttempBoss(spawnPlayer);
        bossManager.SetCanOpenChallenge_1(false);
        bossManager.SetCanOpenChallenge_2(true);
        bossManager.SetCanOpenChallenge_3(false);
        OnChallengeComplete.Invoke();
        bossManager.DoAnimationBoss(1);
    }
}
