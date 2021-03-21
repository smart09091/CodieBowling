using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUIController : MonoBehaviour
{
    public GameObject loadingScreen;
    public GameObject startScreenReference;
    public GameObject joystickReference;
    public GameObject victoryScreenReference;
    public GameObject tutorialReference;
    public Text levelText;
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.Instance.onInitialize += HideLoadingScreen;
        GameEvents.Instance.onRoundFinished += ShowVictoryScreen;
        GameEvents.Instance.onLevelGenerated += SetLevelText;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetLevelText(int currentLevel){
        levelText.text = "Level " + currentLevel;
    }

    public void StartGame(){

        GameEvents.Instance.GeneratePinsFinished();
        startScreenReference.SetActive(false);
        joystickReference.SetActive(true);
        GameEvents.Instance.GameStart();

        if(tutorialReference != null){
            tutorialReference.SetActive(true);
        }
    }

    public void HideLoadingScreen(){
        loadingScreen.SetActive(false);
    }

    public void ShowVictoryScreen(){
        victoryScreenReference.SetActive(true);
    }
    public void HideVictoryScreen(){
        victoryScreenReference.SetActive(false);
    }

    public void NextLevel(){
        loadingScreen.SetActive(true);
        victoryScreenReference.SetActive(false);
        GameEvents.Instance.NextLevel();
        startScreenReference.SetActive(true);
        joystickReference.SetActive(false);
    }

    public void LoadNextLevel(){
        SceneManager.LoadScene("GameSceneDynamic");
    }
}
