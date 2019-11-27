using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChangeScenesManager : MonoBehaviour    
{
    [SerializeField] SceneTransitions sceneTransition;
    [SerializeField] int indexToLoad;
    public void LoadSceen()
    {
        sceneTransition.SceneIndexToLoad(indexToLoad);
    }
}
