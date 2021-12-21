using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text highScoreText;
    [SerializeField] private TMP_Text energyText;
    [SerializeField] private int maxEnergy;
    /** this value will be passed to the script from Unity - you can type it in the editor */
    [SerializeField] private int energyRechargeDuration;

    private int energy;

    private const string EnergyKey = "Energy";
    private const string EnergyReadyKey = "EnergyReady";

    /** we want to load the highest score every time we load a MainMenu scene - thats why we use Start() method */
    public void Start()
    {
        Debug.Log("Starting the game");
        int highScore = PlayerPrefs.GetInt(ScoreSystem.HighScoreKey, 0);
        // highScoreText.text = highScore.ToString();
        /** or bellow solution which is like gravis symbol in JS = "High Score: " + highScore.ToString() */
        highScoreText.text = $"High Score: {highScore}";

        /** when the game load lets check how much energy we got */
        energy = PlayerPrefs.GetInt(EnergyKey, maxEnergy);

        if (energy == 0)
        {
            /** if we out of energy check when the energy should be regenerated */
            string energyReadyString = PlayerPrefs.GetString(EnergyReadyKey, string.Empty);
            /** if there is an error */
            if (energyReadyString == string.Empty)
            {
                return;
            }

            /** parse string to DateTime */
            DateTime energyReady = DateTime.Parse(energyReadyString);
            /** if the current date time is greater than when the energy is ready - 
            so we already pasted that point in time */
            if (DateTime.Now > energyReady)
            {
                energy = maxEnergy;
                PlayerPrefs.SetInt(EnergyKey, energy);
            }
        }

        energyText.text = $"Play ({energy})";
    }
    public void Play()
    {
        if (energy < 1)
        {
            return;
        }
        energy = energy - 1;
        PlayerPrefs.SetInt(EnergyKey, energy);

        if (energy == 0)
        {
            Debug.Log("Countdown started");
            DateTime timeWhenEnergyWillRecharge = DateTime.Now.AddMinutes(energyRechargeDuration);
            PlayerPrefs.SetString(EnergyReadyKey, timeWhenEnergyWillRecharge.ToString());
        }
        /** Main Menu scene = 0 so the Game scene = 1 */
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
