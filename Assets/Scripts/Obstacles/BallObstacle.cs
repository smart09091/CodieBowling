using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallObstacle : MonoBehaviour
{
    public LevelBallObstacle levelBallObstacleReference;
    [Range(0,2)]
    public int ballType;
    public float ballScaleValue = .5f;
    public bool interactible = true;
    void Start(){
        AssignObstacleMaterial();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(interactible){
            if(other.tag == "Ball"){
                gameObject.SetActive(false);
                GameEvents.Instance.OnBallObstacleHit(ballType, ballScaleValue);
                levelBallObstacleReference.DeactivateObstacles();
            }
        }
    }

    private void AssignObstacleMaterial(){
        GetComponent<MeshRenderer>().material = MaterialManager.Instance.ballObstacleMaterials[ballType];
    }
    
}
