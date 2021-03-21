using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GaugeController : MonoBehaviour
{
    public Slider gaugeReference;
    public Button gaugeButtonReference;
    public float gaugeMinValue = 1000f;
    public float gaugeMaxValue = 5000f;
    public float gaugeSpeed = 5f;
    public bool increment;
    public bool forceApplied = false;

    void Start(){
        gaugeReference.value = Random.Range(gaugeMaxValue, gaugeMaxValue);
        var random = new System.Random();
        increment = random.Next(2) == 1;

        GameEvents.Instance.onFinishLineCrossed += ShowGauge;
        GameEvents.Instance.onKickStart += ApplyMinimumForce;

        gaugeReference.gameObject.SetActive(false);
        gaugeButtonReference.gameObject.SetActive(false);
    }
    
    void Update(){
        if(!forceApplied){
            if(increment){
                gaugeReference.value += gaugeSpeed;
                if(gaugeReference.value >= gaugeMaxValue){
                    gaugeReference.value = gaugeMaxValue;
                    increment = !increment;
                }
            }else{
                gaugeReference.value -= gaugeSpeed;
                if(gaugeReference.value <= gaugeMinValue){
                    gaugeReference.value = gaugeMinValue;
                    increment = !increment;
                }
            }
        }
    }

    public void ShowGauge(){
        gaugeReference.gameObject.SetActive(true);
        gaugeButtonReference.gameObject.SetActive(true);
    }
    public void ApplyMinimumForce(){
        if(!forceApplied){
            gaugeReference.value = gaugeMinValue;
            GameEvents.Instance.GaugeForceApplied(gaugeReference.value);
            forceApplied = true;
            gaugeButtonReference.gameObject.SetActive(false);
        }
    }

    public void ApplyForce(){
        forceApplied = true;

        GameEvents.Instance.GaugeForceApplied(gaugeReference.value);
    }
}
