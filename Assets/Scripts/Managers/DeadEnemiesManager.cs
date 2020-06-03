using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DeadEnemiesManager : MonoBehaviour
{
    [SerializeField]
    int currentEnemies;
    int enemiesDead = 0;
    public UnityEvent OnAfterDie;

    public void AddDead()
    {
        enemiesDead++;
        DoActionAfterDead();
    }
    void DoActionAfterDead()
    {
        if(enemiesDead == currentEnemies)
        {
            OnAfterDie.Invoke();
        }
    }
}
