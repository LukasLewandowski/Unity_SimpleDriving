using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text highScoreText;

    /** we want to load the highest score every time we load a MainMenu scene - thats why we use Start() method */
    public void Start()
    {
        int highScore = PlayerPrefs.GetInt(ScoreSystem.HighScoreKey, 0);
        // highScoreText.text = highScore.ToString();
        /** or bellow solution which is like gravis symbol in JS = "High Score: " + highScore.ToString() */
        highScoreText.text = $"High Score: {highScore}";
    }
    public void Play()
    {
        /** Main Menu scene = 0 so the Game scene = 1 */
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
