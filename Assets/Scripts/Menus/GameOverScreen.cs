using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Screen for a game over
/// </summary>
public class GameOverScreen : MonoBehaviour
{
    [SerializeField] Text finalScore;
    
    #region Methods

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        // Freeze game objects
        Time.timeScale = 0;
        
        // Set final score text
        finalScore.text = "Final Score\n\nLevel: " + PlayerPrefs.GetInt(
                "Current Level") + "\nTime Elapsed: " + (int)PlayerPrefs.GetFloat(
                    "Current Time Elapsed") + " sec";
    }

    /// <summary>
    /// Return to main menu
    /// </summary>
    public void HandleQuitButtonOnClickEvent()
    {
        // Unfreeze game and destroy menu
        Time.timeScale = 1;
        Destroy(gameObject);
        MenuManager.GoToMenu(MenuName.Main);
    }

    #endregion
}
