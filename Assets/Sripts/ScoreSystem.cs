using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private float scoreMultiplayer = 1;
    private float score;
    public const string HighScoreKey = "HighScore";

    // Update is called once per frame
    void Update()
    {
        score += Time.deltaTime * scoreMultiplayer;
        /** convert score from float to int and round the number */
        int roundedScore = Mathf.FloorToInt(score);
        scoreText.text = roundedScore.ToString();
    }

    /** onDestry method is called automatically like "Start", "Update", "onTrigger" */
    private void OnDestroy()
    {
        int currentHighestScore = PlayerPrefs.GetInt(HighScoreKey, 0);
        if (score > currentHighestScore)
        {
            PlayerPrefs.SetInt(HighScoreKey, Mathf.FloorToInt(score));
        }
    }
}
