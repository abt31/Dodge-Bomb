using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Main Menu scene
/// </summary>
public class MainMenu : MonoBehaviour
{
    #region Methods

    /// <summary>
    /// Start the game
    /// </summary>
    public void HandlePlayButtonOnClickEvent()
    {
        SceneManager.LoadScene("Gameplay");
    }

    /// <summary>
    /// Load help menu
    /// </summary>
    public void HandleHelpButtonOnClickEvent()
    {
        MenuManager.GoToMenu(MenuName.Help);
    }

    /// <summary>
    /// Load high score menu prefab
    /// </summary>
    public void HandleHighScoreButtonOnClickEvent()
    {
        MenuManager.GoToMenu(MenuName.HighScore);
    }

    /// <summary>
    /// Quit the game
    /// </summary>
    public void HandleQuitButtonOnClickEvent()
    {
        Application.Quit();
    }

    #endregion
}
