using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorHook : MonoBehaviour
{
    public Ball ballReference;
    
    public void TriggerPerformKick(){
        Debug.Log("TriggerPerformKick");
        ballReference.PerformKick();
    }
}
