using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportLaberinto : MonoBehaviour
{
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
        bossManager.DoAnimationBoss(1);
    }
}
