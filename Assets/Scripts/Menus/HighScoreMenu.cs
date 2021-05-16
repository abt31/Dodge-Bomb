using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreMenu : MonoBehaviour
{
    [SerializeField] Text highScore;
    
    #region Methods

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        // get and display high score
        if(PlayerPrefs.HasKey("High Level"))
        {
            highScore.text = "High Score\n\nLevel: " + PlayerPrefs.GetInt(
                "High Level") + "\nTime Elapsed: " + (int)PlayerPrefs.GetFloat(
                    "Time Elapsed") + " sec";
        }
        else
        {
            highScore.text = "No games played yet";
        }
    }

    /// <summary>
    /// Return to main menu
    /// </summary>
    public void HandleQuitButtonOnClickEvent()
    {
        // Destroy menu
        Destroy(gameObject);
        MenuManager.GoToMenu(MenuName.Main);
    }

    #endregion
}
