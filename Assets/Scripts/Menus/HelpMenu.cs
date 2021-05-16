using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Help menu screen
/// </summary>
public class HelpMenu : MonoBehaviour
{
    /// <summary>
    /// Return to main menu
    /// </summary>
    public void HandleBackButtonOnClickEvent()
    {
        MenuManager.GoToMenu(MenuName.Main);
    }
}
