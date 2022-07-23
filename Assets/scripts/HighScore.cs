using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    [SerializeField] private Text topScoreText, currentScoreText;
    private void Start()
    {
        int topScore = PlayerPrefs.GetInt("topScore");
        int currentScore = PlayerPrefs.GetInt("Score");
        if(currentScore > topScore)
        {
            PlayerPrefs.SetInt("topScore", currentScore);
        }
        currentScoreText.text = PlayerPrefs.GetInt("Score").ToString();
        topScoreText.text = PlayerPrefs.GetInt("topScore").ToString();
    }


}
