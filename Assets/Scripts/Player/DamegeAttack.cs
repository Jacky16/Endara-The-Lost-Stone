using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamegeAttack : MonoBehaviour
{
    [SerializeField]
    PlayerLifeManager _playerLifeManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Detection Enemy")
        {
            _playerLifeManager.SubstractLife();
        }
    }
}
