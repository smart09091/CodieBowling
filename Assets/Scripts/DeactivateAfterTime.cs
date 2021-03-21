using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateAfterTime : MonoBehaviour
{
    public float deactivateTime = 2f;
    public float currentTime = 0f;
    bool deactivated = false;

    // Update is called once per frame
    void Update()
    {
        if(!deactivated){
            currentTime += Time.deltaTime * 1;
            if(currentTime >= deactivateTime){
                gameObject.SetActive(false);
                deactivated = true;
            }
        }
    }
}
