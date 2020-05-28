using Cinemachine;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class OpenWallForest : MonoBehaviour
{
    [SerializeField] PlayableDirector playableDirector;
    bool cinematicPlayed;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Caja" || other.gameObject.name == "Llave" && !cinematicPlayed)
        {
            cinematicPlayed = true;
            if (cinematicPlayed)
            {
                other.GetComponent<ObjetoPickeable>().isPickeable = false;
                Invoke("PlayCinematic",1f);
            }
        }
    }

    void PlayCinematic()
    {
        playableDirector.Play();
        cinematicPlayed = false;
    }

}
