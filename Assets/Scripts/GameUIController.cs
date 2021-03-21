using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIController : MonoBehaviour
{
    public GameObject startScreenReference;
    public GameObject joystickReference;
    public GameObject victoryScreenReference;
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.Instance.onRoundFinished += ShowVictoryScreen;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame(){
        startScreenReference.SetActive(false);
        joystickReference.SetActive(true);
        GameEvents.Instance.GameStart();
    }

    public void ShowVictoryScreen(){
        victoryScreenReference.SetActive(true);
    }
    public void HideVictoryScreen(){
        victoryScreenReference.SetActive(false);
    }
}
