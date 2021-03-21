using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public Transform playerSpawnPoint;
    public GameObject playerReference;

    void Start(){
        playerReference.transform.position = playerSpawnPoint.position;
    }

}
