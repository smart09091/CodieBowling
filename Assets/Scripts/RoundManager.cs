using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    public float roundEndTimer;
    bool roundFinished = false;

    void Start(){
        GameEvents.Instance.onGameStart += ResetRound;
    }

    void FinishRound(){
        Debug.Log("FinishRound");
        GameEvents.Instance.RoundFinished();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!roundFinished){
            if(other.transform.tag == "Ball")
            {
                roundFinished = true;
                Invoke("FinishRound", roundEndTimer);
            }
        }
    }

    void ResetRound(){
        roundFinished = false;
    }
}
