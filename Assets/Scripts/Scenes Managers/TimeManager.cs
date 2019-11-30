using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeManager : MonoBehaviour
{
    float currentTime;
    [SerializeField] float startTime;
    PlayerMovement playerMovement;
    [SerializeField] TextMeshProUGUI timerText;
    void Start()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        currentTime = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        CountDown();
    }
    public void CountDown()
    {
        currentTime -= Time.deltaTime;
        timerText.text = currentTime.ToString("0");
        if(currentTime <= 0)
        {
            playerMovement.PlayerDead();
        }
    }
    public void ResetTime()
    {
        currentTime = startTime;
    }

}
