using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuerteCaidaManager : MonoBehaviour
{
    [SerializeField]
    Animator animDeadCaida;
    [SerializeField] PlayerMovement player;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
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
        yield return new WaitForSeconds(.5f);
        animDeadCaida.SetTrigger("DeadCaida_End");


    }
}
