using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents Instance;
    public event Action onFinishLineCrossed;
    public event Action<float> onGaugeForceApplied;
    void Awake(){
        Instance = this;
    }

    public void  FinishLineCrossed(){
        if(onFinishLineCrossed != null){
            onFinishLineCrossed();
        }
    }

    public void GaugeForceApplied(float force){
        if(onGaugeForceApplied != null){
            onGaugeForceApplied(force);
        }
    }
}
