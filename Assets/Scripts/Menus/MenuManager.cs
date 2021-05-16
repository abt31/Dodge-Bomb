using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// A menu manager
/// </summary>
public static class MenuManager
{
    /// <summary>
    /// Load a menu
    /// </summary>
    /// <param name="name">menu name</param>
    public static void GoToMenu(MenuName name)
    {
        switch(name)
        {
            case MenuName.Help:
                SceneManager.LoadScene("HelpMenu");
                break;
            case MenuName.Main:
                SceneManager.LoadScene("MainMenu");
                break;
            case MenuName.Pause:
                Object.Instantiate(Resources.Load("PauseMenu"));
                break;
            case MenuName.HighScore:
                GameObject mainMenuCanvas = GameObject.Find("MainMenuCanvas");
                mainMenuCanvas.SetActive(false);
                Object.Instantiate(Resources.Load("HighScoreMenu"));
                break;
            case MenuName.GameOver:
                Object.Instantiate(Resources.Load("GameOverScreen"));
                break;
        }
    }
}
