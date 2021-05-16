using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// An event manager
/// </summary>
public static class EventManager
{
    #region Fields

    // Invoker lists
    static List<HUD> levelUpInvokers = new List<HUD>();
    static List<HUD> playerWonInvokers = new List<HUD>();
    static List<Player> playerDiedInvokers = new List<Player>();

    // Listener lists
    static List<UnityAction<int>> levelUpListeners = new List<UnityAction<int>>();
    static List<UnityAction> playerWonListeners = new List<UnityAction>();
    static List<UnityAction> playerDiedListeners = new List<UnityAction>();

    #endregion

    #region Methods

    /// <summary>
    /// Adds invoker for level up event
    /// </summary>
    /// <param name="invoker">an invoker for level up event</param>
    public static void AddLevelUpInvoker(HUD invoker)
    {
        levelUpInvokers.Add(invoker);
        foreach(UnityAction<int> listener in levelUpListeners)
        {
            invoker.AddLevelUpListener(listener);
        }
    }

    /// <summary>
    /// Adds listener for level up event
    /// </summary>
    /// <param name="listener">a listener for level up event</param>
    public static void AddLevelUpListener(UnityAction<int> listener)
    {
        levelUpListeners.Add(listener);
        foreach(HUD invoker in levelUpInvokers)
        {
            invoker.AddLevelUpListener(listener);
        }
    }

    /// <summary>
    /// Adds invoker for player died event
    /// </summary>
    /// <param name="invoker">an invoker for player died event</param>
    public static void AddPlayerDiedInvoker(Player invoker)
    {
        playerDiedInvokers.Add(invoker);
        foreach(UnityAction listener in playerDiedListeners)
        {
            invoker.AddPlayerDiedListener(listener);
        }
    }

    /// <summary>
    /// Adds listener for player died event
    /// </summary>
    /// <param name="listener">a listener for player died event</param>
    public static void AddPlayerDiedListener(UnityAction listener)
    {
        playerDiedListeners.Add(listener);
        foreach(Player invoker in playerDiedInvokers)
        {
            invoker.AddPlayerDiedListener(listener);
        }
    }

    /// <summary>
    /// Adds invoker for player won event
    /// </summary>
    /// <param name="invoker">an invoker for player won event</param>
    public static void AddPlayerWonInvoker(HUD invoker)
    {
        playerWonInvokers.Add(invoker);
        foreach(UnityAction listener in playerWonListeners)
        {
            invoker.AddPlayerWonListener(listener);
        }
    }

    /// <summary>
    /// Adds listener for player won event
    /// </summary>
    /// <param name="listener">a listener for player won event</param>
    public static void AddPlayerWonListener(UnityAction listener)
    {
        playerWonListeners.Add(listener);
        foreach(HUD invoker in playerWonInvokers)
        {
            invoker.AddPlayerWonListener(listener);
        }
    }

    #endregion
}
