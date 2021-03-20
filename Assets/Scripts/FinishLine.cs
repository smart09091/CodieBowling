using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public Ball ballReference;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player"){
            Debug.Log("Player has crossed finishline");
            GameManager.Instance.FinishLineCrossed();
        }
    }
}
