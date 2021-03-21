using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public Text scoreTextReference;
    void Start(){
        GameEvents.Instance.onScoreUpdated += UpdateScoreText;
    }

    public void UpdateScoreText(int score){
        Debug.Log("UpdateScoreText");
        scoreTextReference.text = "Score: " + score;
    }
}
