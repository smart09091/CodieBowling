using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallObstacle : MonoBehaviour
{
    public LevelBallObstacle levelBallObstacleReference;
    [Range(0,2)]
    public int ballType;
    public float ballScaleValue = .5f;
    public float ballForceValue = 1250f;
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
        if(interactible){
            if(other.tag == "Ball"){
                gameObject.SetActive(false);
                GameEvents.Instance.BallObstacleHit(ballType, ballScaleValue, ballForceValue);
                levelBallObstacleReference.DeactivateObstacles();
            }
        }
    }

    private void AssignObstacleMaterial(){
        GetComponent<MeshRenderer>().material = MaterialManager.Instance.ballObstacleMaterials[ballType];
    }
    
}
