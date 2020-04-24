using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadMenu",8);
    }

    void LoadMenu()
    {
        SceneManager.LoadScene("MainMenuScreen");
    }
}
