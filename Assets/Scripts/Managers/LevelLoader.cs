using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    [SerializeField]
    string _sceneToLoad;

    [SerializeField]
    GameObject _canvasLoadingScreen;

    [SerializeField]
    Slider slider;
    private void Start()
    {
        _canvasLoadingScreen.SetActive(false);
    }
    public void LoadScene()
    {
        StartCoroutine(LoadAsync(_sceneToLoad));
    }
    IEnumerator LoadAsync(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        _canvasLoadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            float progressBar = Mathf.Clamp01(operation.progress / 0.9f);
            slider.value = progressBar;
            yield return null;
        }
    }
}
