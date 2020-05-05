using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MuerteCaidaManager : MonoBehaviour
{
    [SerializeField]
    Animator animDeadCaida;
    [SerializeField] PlayerMovement player;
    [SerializeField] UnityEvent onDead;
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            StartCoroutine(DeadFallAnimationCanvas());
        }
    }
    IEnumerator DeadFallAnimationCanvas() //Cuando te caes al vacio
    {
        if (player.playerIn2D)
        {
            player.SetPlayer2D(false);
        }
        animDeadCaida.SetTrigger("DeadCaida_Start");
        yield return new WaitForSeconds(1);
        player.RespawnToWaypoint();
        onDead.Invoke();
        yield return new WaitForSeconds(.5f);
        animDeadCaida.SetTrigger("DeadCaida_End");


    }
}
