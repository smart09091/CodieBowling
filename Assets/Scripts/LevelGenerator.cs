using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public int levelLabel = 1;
    public int currentLevel = -1;
    public List<LevelDefinition> levels;
    public GameObject levelStartPrefab;
    public GameObject levelStartReference;
    public GameObject levelBallObstaclePrefab;
    public List<LevelBallObstacle> ballObstacles;
    public GameObject levelWallObstaclePrefab;
    public List<LevelWallObstacle> wallObstacles;
    public GameObject levelEndPrefab;
    public GameObject levelEndReference;

    public void Start(){
        GameEvents.Instance.onInitialize += GenerateLevel;
        GameEvents.Instance.onNextLevel += UnloadLevel;
    }

    public void OnDestroy(){
        GameEvents.Instance.onInitialize -= GenerateLevel;
        GameEvents.Instance.onNextLevel -= UnloadLevel;
    }

    public void GenerateLevel(){
        Debug.Log("GenerateLevel");
        levelLabel++;
        currentLevel++;

        if(currentLevel >= levels.Count){
            currentLevel = 0;
        }

        LevelDefinition level = levels[currentLevel];

        if(levelStartReference == null){
            levelStartReference = GameObject.Instantiate(levelStartPrefab);
            levelStartReference.transform.position = Vector3.zero;
        }

        DeactivateBallObstacles();
        CheckPooledBallObstacles(level);

        int maxWallObstacles = (level.numberOfObstacles/ level.obstaclesPerWall) - 1;

        DeactivateWallObstacles();
        CheckPooledWallObstacles(level, maxWallObstacles);
        
        int wallObstacleIndex = 0;

        for(int i = 0; i < level.numberOfObstacles; i++){
            if(i == 0){
                ballObstacles[i].transform.position = levelStartReference.GetComponent<PlayerSpawner>().connectionPoint.transform.position;
            }else
            if(i%level.obstaclesPerWall == 0 && wallObstacleIndex < wallObstacles.Count){
                wallObstacles[wallObstacleIndex].transform.position = ballObstacles[i-1].connectionPoint.transform.position;
                ballObstacles[i].transform.position = wallObstacles[wallObstacleIndex].connectionPoint.transform.position;
                wallObstacles[wallObstacleIndex].RandomizeWall();
                wallObstacles[wallObstacleIndex].gameObject.SetActive(true);
                wallObstacleIndex++;
            }else{
                ballObstacles[i].transform.position = ballObstacles[i-1].connectionPoint.transform.position;
            }

            ballObstacles[i].gameObject.SetActive(true);
            ballObstacles[i].ballForceValue = level.obstacleBallForceValue;
            ballObstacles[i].RandomizeObstcles();
        }
        
        if(levelEndReference == null){
            levelEndReference = GameObject.Instantiate(levelEndPrefab);
        }

        levelEndReference.transform.position = ballObstacles[level.numberOfObstacles - 1].connectionPoint.transform.position;

        GameEvents.Instance.LevelGenerated(levelLabel);

        PinManager pinManager =  levelEndReference.GetComponent<PinManager>();
        pinManager.SpawnPins(level);
    }

    void DeactivateBallObstacles(){
        Debug.Log("DeactivateBallObstacles");
        foreach(LevelBallObstacle ballObstacle in ballObstacles){
            ballObstacle.gameObject.SetActive(false);
        }
    }

    void CheckPooledBallObstacles(LevelDefinition level){
        if(ballObstacles.Count < level.numberOfObstacles){
            int obstaclePoolDifference = level.numberOfObstacles - ballObstacles.Count;
            //Add obstacles to current pool
            for(int i = 0; i < obstaclePoolDifference; i++){
                GameObject ballObstacle = GameObject.Instantiate(levelBallObstaclePrefab);
                ballObstacles.Add(ballObstacle.GetComponent<LevelBallObstacle>());
                ballObstacle.SetActive(false);
            }
        }
    }

    void DeactivateWallObstacles(){
        foreach(LevelWallObstacle wallObstacle in wallObstacles){
            wallObstacle.gameObject.SetActive(false);
        }
    }

    void CheckPooledWallObstacles(LevelDefinition level, int maxWallObstacles){
        if(wallObstacles.Count < maxWallObstacles){
            int obstaclePoolDifference = maxWallObstacles - wallObstacles.Count;
            //Add obstacles to current pool
            for(int i = 0; i < obstaclePoolDifference; i++){
                GameObject wallObstacle = GameObject.Instantiate(levelWallObstaclePrefab);
                wallObstacles.Add(wallObstacle.GetComponent<LevelWallObstacle>());
                wallObstacle.SetActive(false);
            }
        }
    }

    public void UnloadLevel(){
        DeactivateBallObstacles();
        DeactivateWallObstacles();
    }
}
