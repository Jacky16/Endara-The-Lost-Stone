using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class Portal : MonoBehaviour
{
    [SerializeField]
    PlayableDirector playableDirector;

    private void OnTriggerEnter(Collider other)
    {
        playableDirector.Play();
    }
}
