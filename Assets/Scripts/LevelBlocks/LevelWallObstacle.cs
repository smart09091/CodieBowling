using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelWallObstacle : LevelBlock
{
    public WallObstacle wallObstacle;
    public bool isDynamic = true;
    
    void Start(){
        GameEvents.Instance.onGameStart += RandomizeWall;
    }
    
    void OnDestroy(){
        GameEvents.Instance.onGameStart -= RandomizeWall;
    }
    
    public void RandomizeWall(){
        if(isDynamic){
            wallObstacle.wallType = Random.Range(0,3);
            wallObstacle.gameObject.SetActive(true);
        }
    }
}
