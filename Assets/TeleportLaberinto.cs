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
    }
}
