using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    public float roundEndTimer;

    void FinishRound(){
        Debug.Log("FinishRound");
        GameEvents.Instance.RoundFinished();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Ball")
        {
            Invoke("FinishRound", roundEndTimer);
        }
    }
}
