using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    bool recordScore = true;
    public bool hasRecordedScore = false;
    Rigidbody rigidbody;
    void Awake(){
        rigidbody = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.Instance.onGeneratePinsFinished += EnablePinPhysics;
        GameEvents.Instance.onRoundFinished += DisabeRecordScore;
    }
    
    void OnDestroy() {
        GameEvents.Instance.onGeneratePinsFinished -= EnablePinPhysics;
        GameEvents.Instance.onRoundFinished -= DisabeRecordScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisablePinPhysics(){
        rigidbody.isKinematic = true;
    }

    public void EnablePinPhysics(){
        rigidbody.isKinematic = false;
    }

    public void RecordScore(){
        if(recordScore){
            if(!hasRecordedScore){
                hasRecordedScore = true;
                GameManager.Instance.IncrementScore();
            }
        }
    }

    public void RemoveScore(){
        if(recordScore){
            if(hasRecordedScore){
                hasRecordedScore = false;
                GameManager.Instance.DecrementScore();
            }
        }
    }
    public void EnableRecordScore(){
        recordScore = true;
    }
    public void DisabeRecordScore(){
        recordScore = false;
    }
}
