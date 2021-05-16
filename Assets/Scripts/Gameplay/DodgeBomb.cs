using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Main game script
/// </summary>
public class DodgeBomb : MonoBehaviour
{
    #region Methods

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        // Add event listeners
        EventManager.AddPlayerDiedListener(HandlePlayerDied);
        EventManager.AddPlayerWonListener(HandlePlayerWon);
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        // Pause game with escape key
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            MenuManager.GoToMenu(MenuName.Pause);
        }
    }

    /// <summary>
    /// Save score if new high score and load high score menu
    /// </summary>
    void HandlePlayerDied()
    {
        // Get level and time elapsed of current game
        HUD hudScript = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
        int level = hudScript.Level;
        float timeElapsed = hudScript.TimeElapsed;
        
        // Save high score if it is one
        if(!PlayerPrefs.HasKey("High Level"))
        {
            SaveHighScore(level, timeElapsed);
        }
        else
        {
            int highestLevel = PlayerPrefs.GetInt("High Level");
            float highestTimeElapsed = PlayerPrefs.GetFloat("Time Elapsed");
            if(level > highestLevel || (level == highestLevel && timeElapsed > highestTimeElapsed))
            {
                SaveHighScore(level, timeElapsed);
            }
        }

        // Set current score for access in GameOverScreen
        SaveCurrentScore(level, timeElapsed);

        // Load game over screen
        MenuManager.GoToMenu(MenuName.GameOver);
    }

    /// <summary>
    /// Save score and load high score menu
    /// </summary>
    void HandlePlayerWon()
    {
        SaveHighScore(8, 100);
        SaveCurrentScore(8, 100);
        MenuManager.GoToMenu(MenuName.GameOver);
    }

    /// <summary>
    /// Save new high score
    /// </summary>
    /// <param name="level">level of score</param>
    /// <param name="timeElapsed">time elapsed of score</param>
    void SaveHighScore(int level, float timeElapsed)
    {
        PlayerPrefs.SetInt("High Level", level);
        PlayerPrefs.SetFloat("Time Elapsed", timeElapsed);
        PlayerPrefs.Save();
    }

    /// <summary>
    /// Save current score for usage in GameOverScreen
    /// </summary>
    /// <param name="level">current level</param>
    /// <param name="timeElapsed">current time elapsed</param>
    void SaveCurrentScore(int level, float timeElapsed)
    {
        PlayerPrefs.SetInt("Current Level", level);
        PlayerPrefs.SetFloat("Current Time Elapsed", timeElapsed);
        PlayerPrefs.Save();
    }

    #endregion
}
