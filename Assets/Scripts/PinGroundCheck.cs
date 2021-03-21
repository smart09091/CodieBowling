using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinGroundCheck : MonoBehaviour
{
    public Pin pinReference;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ground"){
            pinReference.RemoveScore();
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Ground"){
            pinReference.RecordScore();
        }
    }
}
