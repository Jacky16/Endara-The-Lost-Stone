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

    Slider slider;
    private void Awake()
    {
        if (_canvasLoadingScreen != null)
            slider = _canvasLoadingScreen.GetComponentInChildren<Slider>();
    }
    private void Start()
    {
        if (_canvasLoadingScreen != null)
            _canvasLoadingScreen.SetActive(false);
    }
    public void LoadScene()
    {
        if(_canvasLoadingScreen != null)
        {
            StartCoroutine(LoadAsync(_sceneToLoad));
        }
        else
        {
            SceneManager.LoadScene(_sceneToLoad);
        }
    }
    IEnumerator LoadAsync(string sceneName)
    {
        yield return new WaitForSeconds(.1f);
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
