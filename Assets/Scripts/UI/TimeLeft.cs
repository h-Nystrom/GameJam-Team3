using System;
using Patient;
using UnityEngine;
using UnityEngine.UI;

public class TimeLeft : MonoBehaviour{
    [SerializeField] float timeLeft = 60f;
    [SerializeField] float addTimeValue = 20f;
    [SerializeField] StringEvent GameOverEvent;
    Text timeCounter => GetComponent<Text>();

    void Start(){
        timeLeft += Time.time;
    }

    void FixedUpdate(){
        var timer = timeLeft - Time.time;
        if (timer <= 0){
            GameOverEvent?.Invoke("Mission Failed!");
            return;
        }
        timeCounter.text = timer.ToString("Time left:\n 0.0");
    }

    public void AddTime(){
        timeLeft += addTimeValue;
    }
}
