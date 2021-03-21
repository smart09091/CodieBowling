using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents Instance;
    public event Action onInitCompleted;
    public event Action onGameStart;
    public event Action onFinishLineCrossed;
    public event Action<float> onGaugeForceApplied;
    public event Action onKickStart;
    public event Action<int> onScoreUpdated;
    public event Action onRoundFinished;
    public event Action<int, float, float> onBallObstacleHit;
    public event Action<float> onGaugeForceUpdated;
    public event Action<int> onWallObstacleHit;
    void Awake(){
        Instance = this;
    }

    public void InitCompleted(){
        if(onInitCompleted != null){
            onInitCompleted();
        }
    }

    public void GameStart(){
        if(onGameStart != null){
            onGameStart();
        }
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
        if(onRoundFinished != null){
            onRoundFinished();
        }
    }

    public void BallObstacleHit(int ballType, float scaleValue, float ballForceValue){
        if(onBallObstacleHit != null){
            onBallObstacleHit(ballType, scaleValue, ballForceValue);
        }
    }

    public void GaugeForceUpdated(float ballForceValue){
        if(onGaugeForceUpdated != null){
            onGaugeForceUpdated(ballForceValue);
        }
    }

    public void WallObstacleHit(int wallType){
        if(onWallObstacleHit != null){
            onWallObstacleHit(wallType);
        }
    }
}
