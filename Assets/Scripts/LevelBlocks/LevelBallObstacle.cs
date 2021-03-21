using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBallObstacle: MonoBehaviour{
    public List<BallObstacle> ballObstacles;
    [Range(0,2)]
    public int ballType;

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
