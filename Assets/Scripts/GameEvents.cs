using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents Instance;
    public event Action onFinishLineCrossed;
    public event Action<float> onGaugeForceApplied;
    public event Action onKickStart;
    public event Action<int> onScoreUpdated;
    public event Action onRoundFinished;
    void Awake(){
        Instance = this;
    }

    public void  FinishLineCrossed(){
        if(onFinishLineCrossed != null){
            onFinishLineCrossed();
        }
    }

    public void GaugeForceApplied(float force){
        if(onGaugeForceApplied != null){
            onGaugeForceApplied(force);
        }
    }

    public void KickStart(){
        if(onKickStart != null){
            onKickStart();
        }
    }

    public void ScoreUpdated(int score){
        if(onScoreUpdated != null){
            onScoreUpdated(score);
        }
    }

    public void RoundFinished(){
        Debug.Log("RoundFinished");
        if(onRoundFinished != null){
            onRoundFinished();
        }
    }
}
