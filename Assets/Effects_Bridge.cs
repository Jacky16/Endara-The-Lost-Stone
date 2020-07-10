using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effects_Bridge : MonoBehaviour
{
    [SerializeField]
    AudioSource musicGamePlay;

    AudioSource musicBridge;

    [SerializeField]
    ParticleSystem[] particleSystems;

    private void Awake()
    {
        musicBridge = GetComponent<AudioSource>();
    }

    public void ActivateEffectsBridge()
    {
        foreach(ParticleSystem ps in particleSystems)
        {
            ps.Play();
        }

        musicGamePlay.DOFade(0, 2);
        musicBridge.DOFade(0.8f, 2).OnStart(() => musicBridge.Play());
    }
    public void DisableEffectsBridge()
    {
        foreach (ParticleSystem ps in particleSystems)
        {
            ps.Stop();
        }

        musicGamePlay.DOFade(.5f, 2);
        musicBridge.DOFade(0f, 2).OnComplete(() => musicBridge.Stop());
    }
}
