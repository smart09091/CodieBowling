using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBallObstacle: LevelBlock{
    public List<BallObstacle> ballObstacles;
    [Range(0,2)]
    public int ballType;
    public float ballForceValue = 1250f;
    
    void Start(){
        GameEvents.Instance.onGameStart += ActivateObstacles;
    }
    
    void OnDestroy(){
        GameEvents.Instance.onGameStart -= ActivateObstacles;
    }

    public void RandomizeObstcles(){
        int[] obstacleValues = {0, 1, 2};

         for (int i = 0; i < obstacleValues.Length; i++) {
             int rnd = Random.Range(0, obstacleValues.Length);
             int temp;
             temp = obstacleValues[rnd];
             obstacleValues[rnd] = obstacleValues[i];
             obstacleValues[i] = temp;
         }

         for(int i = 0; i < ballObstacles.Count; i++){
             ballObstacles[i].ballType = obstacleValues[i];
             ballObstacles[i].ballForceValue = ballForceValue;
             ballObstacles[i].gameObject.SetActive(true);
         }
    }

    public void ActivateObstacles(){
        foreach(BallObstacle ballObstacle in ballObstacles){
            ballObstacle.interactible = true;
        }
    }

    public void DeactivateObstacles(){
        foreach(BallObstacle ballObstacle in ballObstacles){
            ballObstacle.interactible = false;
        }
    }
}
