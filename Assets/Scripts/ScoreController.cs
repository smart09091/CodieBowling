using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public Text scoreTextReference;
    void Start(){
        GameEvents.Instance.onScoreUpdated += UpdateScoreText;
        scoreTextReference.gameObject.SetActive(false);
    }
    void OnDestroy() {
        GameEvents.Instance.onScoreUpdated -= UpdateScoreText;
    }

    public void UpdateScoreText(int score){
        scoreTextReference.gameObject.SetActive(true);
        Debug.Log("UpdateScoreText");
        scoreTextReference.text = "Score: " + score;
    }
}
