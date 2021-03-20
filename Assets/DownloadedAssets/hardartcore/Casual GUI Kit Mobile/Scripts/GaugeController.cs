using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GaugeController : MonoBehaviour
{
    public Slider gaugeReference;
    public float gaugeMinValue = 1000f;
    public float gaugeMaxValue = 5000f;
    public float gaugeSpeed = 5f;
    public bool increment;

    void Start(){
        gaugeReference.value = Random.Range(gaugeMaxValue, gaugeMaxValue);
        var random = new System.Random();
        increment = random.Next(2) == 1;

        GameManager.Instance.onFinishLineCrossed += ShowGauge;
    }
    
    void Update(){
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

    public void ShowGauge(){
        gaugeReference.gameObject.SetActive(true);
    }
}
