using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : LevelBlock
{
    public Transform playerSpawnPoint;
    public GameObject playerReference;
    void Awake(){
        playerReference = GameObject.FindGameObjectWithTag("Player");
    }

    void Start(){
        GameEvents.Instance.onNextLevel += ResetPlayerLocation;
        playerReference.transform.position = playerSpawnPoint.position;
    }

    void OnDestroy(){
        GameEvents.Instance.onNextLevel -= ResetPlayerLocation;

    }

    public void ResetPlayerLocation(){
        playerReference.transform.position = playerSpawnPoint.position;
    }

}
