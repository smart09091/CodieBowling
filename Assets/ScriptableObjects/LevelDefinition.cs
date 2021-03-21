using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Level Definition")]
public class LevelDefinition : ScriptableObject
{
    public float playerForwardSpeed = 7f;
    public float obstacleBallForceValue = 1250f;
    public int numberOfObstacles = 12;
    public int obstaclesPerWall = 3;
    public int pinRows = 3;
}
