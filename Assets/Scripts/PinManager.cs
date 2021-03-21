using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinManager : MonoBehaviour
{
    public GameObject pinPrefab;
    public Transform pinStartPoint;
    public List<Pin> pins;
    int totalPins;
    public float forwardDistance;
    public float sideDistance;
    // Start is called before the first frame update

    void Start(){
        GameEvents.Instance.onNextLevel += ResetPins;
    }

    void OnDestroy(){
        GameEvents.Instance.onNextLevel -= ResetPins;
    }

    public void SpawnPins(LevelDefinition level){
        CheckPooledPins(level);

        int i = 0;

        for(int x = 1; x <= level.pinRows; x++){
            if(x == 1){
                pins[i].transform.position = pinStartPoint.transform.position;
                pins[i].gameObject.SetActive(true);
                i++;
            }else{
                for(int y = 0; y < x; y++){
                    Vector3 pinPosition = new Vector3(
                        pinStartPoint.transform.position.x,
                        pinStartPoint.transform.position.y,
                        pinStartPoint.transform.position.z
                    );
                    pinPosition.z += forwardDistance * (x - 1);
                    float thisSideDistance = sideDistance;
                    if(x % 2 == 0){
                        thisSideDistance = thisSideDistance/2;
                    }
                    float finalSideDistance;
                    if(x%2 != 0){
                        finalSideDistance = ((x/2)*thisSideDistance) - (sideDistance * y);
                    }else{
                        finalSideDistance = ((x-1)*thisSideDistance) - (sideDistance * y);
                    }
                    pinPosition.x += finalSideDistance;
                    pins[i].transform.position = pinPosition;
                    pins[i].gameObject.SetActive(true);
                    i++;
                }
            }
        }
    }

    void ResetPins(){
        foreach(Pin pin in pins){
            pin.DisablePinPhysics();
            Quaternion pinRotation = pin.transform.rotation;
            pinRotation.x = 0;
            pinRotation.y = 180;
            pinRotation.z = 0;

            pin.transform.rotation = pinRotation;
            pin.hasRecordedScore = false;
            pin.EnableRecordScore();
            pin.gameObject.SetActive(false);
        }
    }

    void CheckPooledPins(LevelDefinition level){
        totalPins = CalculateTotalPins(level.pinRows);
        if(pins.Count < totalPins){
            int pinPoolDifference = totalPins - pins.Count;
            //Add obstacles to current pool
            for(int i = 0; i < pinPoolDifference; i++){
                GameObject pin = GameObject.Instantiate(pinPrefab);
                pins.Add(pin.GetComponent<Pin>());
                pin.SetActive(false);
            }
        }
    }

    int CalculateTotalPins(int value){
        int n = value;
        int totalPins = 0;
        while(n != 0){
            totalPins += n;
            n--;
        }

        return totalPins;
    }
}
