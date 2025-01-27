﻿using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicFader : MonoBehaviour
{
    [SerializeField] 
    AudioSource mainMusic;

    [SerializeField] 
    AudioSource audioSourceChallengeMusic;

    [SerializeField]
    AudioClip challengeMusic;
    private void Awake()
    {
        audioSourceChallengeMusic.volume = 0.3f;
    }
    public void FadeInMusic()
    {
        mainMusic.DOFade(0, 1);
        print(mainMusic.volume);
        audioSourceChallengeMusic.DOFade(1f, 1).OnStart(() => audioSourceChallengeMusic.PlayOneShot(challengeMusic));
    }
    public void FadeOutMusic()
    {
        mainMusic.DOFade(.5f, 1);
        audioSourceChallengeMusic.DOFade(0f, 1);
    }


}
