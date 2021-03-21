using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMaterialController : MonoBehaviour
{
    public SkinnedMeshRenderer playerMeshRenderer;
    public MeshRenderer ballMeshRenderer;
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.Instance.onWallObstacleHit += ChangePlayerMaterials;
    }
    void OnDestroy() {
        GameEvents.Instance.onWallObstacleHit -= ChangePlayerMaterials;
    }

    public void ChangePlayerMaterials(int wallType){
        playerMeshRenderer.material = MaterialManager.Instance.playerMaterials[wallType];
        ballMeshRenderer.material = MaterialManager.Instance.ballObstacleMaterials[wallType];
    }
}
