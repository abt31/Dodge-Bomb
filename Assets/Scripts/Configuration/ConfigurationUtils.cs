using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides access to configuration data
/// </summary>
public static class ConfigurationUtils
{
    static ConfigurationData configurationData;

    #region Properties

    /// <summary>
    /// Gets the player move units per second
    /// </summary>
    /// <value>player move units per second</value>
    public static float PlayerMoveUnitsPerSecond
    {
        get { return configurationData.PlayerMoveUnitsPerSecond; }
    }

    /// <summary>
    /// Gets the bomb move units per second initially
    /// </summary>
    /// <value>bomb initial impulse force</value>
    public static float BombInitialImpulseForce
    {
        get { return configurationData.BombInitialImpulseForce; }
    }

    /// <summary>
    /// Gets the amount the bomb speeds up by
    /// </summary>
    /// <value>bomb speedup add force</value>
    public static float BombSpeedupAddForce
    {
        get { return configurationData.BombSpeedupAddForce; }
    }

    /// <summary>
    /// Gets the minimum spawn time for bombs
    /// </summary>
    /// <value>minimum spawn time</value>
    public static float MinSpawnTime
    {
        get { return configurationData.MinSpawnTime; }
    }

    /// <summary>
    /// Gets the maximum spawn time for bombs
    /// </summary>
    /// <value>maximum spawn time</value>
    public static float MaxSpawnTime
    {
        get { return configurationData.MaxSpawnTime; }
    }

    /// <summary>
    /// Gets the amount of time for the first level
    /// </summary>
    /// <value>amount of time for first level</value>
    public static int InitialLevelTimer
    {
        get { return configurationData.InitialLevelTimer; }
    }

    /// <summary>
    /// Gets the amount of time added on a level up
    /// </summary>
    /// <value>amount of time added each level</value>
    public static int LevelTimerIncrease
    {
        get { return configurationData.LevelTimerIncrease; }
    }

    #endregion

    /// <summary>
    /// Initializes the configuration data
    /// </summary>
    public static void Initialize()
    {
        configurationData = new ConfigurationData();
    }
}
