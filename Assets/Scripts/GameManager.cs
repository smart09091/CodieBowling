using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int score;
    void Awake(){
        Instance = this;

    }

    void Start(){
        //GameEvents.Instance.Initialize();
        GameEvents.Instance.onNextLevel += NextLevel;
        Invoke("Initialize", .25f);
        GameEvents.Instance.InitCompleted();
    }

    public void Initialize(){
        Debug.Log("Initialize");
        GameEvents.Instance.Initialize();
    }

    public void NextLevel(){
        Invoke("Initialize", .25f);
    }

    public void SetScore(int value){
        score = value;
    }

    public int GetScore(){
        return score;
    }

    public void IncrementScore(){
        score++;
        GameEvents.Instance.ScoreUpdated(score);
    }

    public void DecrementScore(){
        score--;
        GameEvents.Instance.ScoreUpdated(score);
    }
}
