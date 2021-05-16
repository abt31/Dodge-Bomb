using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Display for paused game
/// </summary>
public class PauseMenu : MonoBehaviour
{
    #region Methods

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        // Freeze all objects
        Time.timeScale = 0;
    }

    /// <summary>
    /// Resume the game
    /// </summary>
    public void HandleResumeButtonOnClickEvent()
    {
        // Unfreeze objects and destroy menu
        Time.timeScale = 1;
        Destroy(gameObject);
    }

    /// <summary>
    /// Return to main menu
    /// </summary>
    public void HandleQuitButtonOnClickEvent()
    {
        // Unfreeze objects and destroy menu
        Time.timeScale = 1;
        Destroy(gameObject);
        MenuManager.GoToMenu(MenuName.Main);
    }

    #endregion
}
