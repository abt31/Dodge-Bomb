using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

/// <summary>
/// HUD to display game info on the screen
/// </summary>
public class HUD : MonoBehaviour
{
    #region Fields

    // Time left support
    static Text timeLeftText;
    static string timeLeftPrefix = "Time until next level: ";
    int levelTime;
    Timer levelTimer;

    // Level support
    static Text levelText;
    static string levelPrefix = "Level: ";
    int level;
    LevelUp levelUp;

    // Game win support
    PlayerWon playerWon;

    #endregion

    #region Properties

    /// <summary>
    /// Gets the level
    /// </summary>
    public int Level
    {
        get { return level; }
    }

    /// <summary>
    /// Gets the time elapsed for current level
    /// </summary>
    public float TimeElapsed
    {
        get { return levelTimer.TimeElapsed; }
    }

    #endregion

    #region Methods

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        // Start level timer
        levelTime = ConfigurationUtils.InitialLevelTimer;
        levelTimer = gameObject.AddComponent<Timer>();
        levelTimer.Duration = ConfigurationUtils.InitialLevelTimer + 1;
        levelTimer.AddTimerFinishedListener(HandleLevelTimerFinished);
        levelTimer.Run();

        // Set level
        level = 1;

        // Initialize text
        timeLeftText = GameObject.FindGameObjectWithTag("TimeLeftText").GetComponent<Text>();
        levelText = GameObject.FindGameObjectWithTag("LevelText").GetComponent<Text>();
        timeLeftText.text = timeLeftPrefix + levelTime;
        levelText.text = levelPrefix + level;

        // Initialize events and add class as invoker
        levelUp = new LevelUp();
        playerWon = new PlayerWon();
        EventManager.AddLevelUpInvoker(this);
        EventManager.AddPlayerWonInvoker(this);
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        // Update text for timer
        timeLeftText.text = timeLeftPrefix + (int)levelTimer.SecondsLeft;
    }

    /// <summary>
    /// Trigger level up event when timer finishes and change text
    /// </summary>
    void HandleLevelTimerFinished()
    {
        levelTimer.Stop();
        level++;
        
        // 8 levels in the game
        if(level <= 8)
        {
            levelUp.Invoke(level);
            levelText.text = levelPrefix + level;
            levelTime += ConfigurationUtils.LevelTimerIncrease;
            levelTimer.Duration = levelTime;
            levelTimer.Run();
            timeLeftText.text = timeLeftPrefix + levelTime;
        }
        else
        {
            // Invoke player won event
            playerWon.Invoke();
        }
    }

    /// <summary>
    /// Adds listener for level up event
    /// </summary>
    /// <param name="listener">listener for level up event</param>
    public void AddLevelUpListener(UnityAction<int> listener)
    {
        levelUp.AddListener(listener);
    }

    public void AddPlayerWonListener(UnityAction listener)
    {
        playerWon.AddListener(listener);
    }

    #endregion
}
