using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallObstacle : MonoBehaviour
{
    [Range(0,2)]
    public int wallType;
    public float ballScaleValue = .5f;
    public bool interactible = true;
    void Start(){
        AssignObstacleMaterial();
        GameEvents.Instance.onGameStart += AssignObstacleMaterial;
    }
    void OnDestroy(){
        AssignObstacleMaterial();
        GameEvents.Instance.onGameStart -= AssignObstacleMaterial;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ball"){
            GameEvents.Instance.WallObstacleHit(wallType);
        }
    }

    private void AssignObstacleMaterial(){
        GetComponent<MeshRenderer>().material = MaterialManager.Instance.wallObstacleMaterials[wallType];
    }
}
