using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// A container for the configuration data
/// </summary>
public class ConfigurationData
{
    #region Fields

    const string ConfigurationDataFileName = "ConfigurationData.csv";
    Dictionary<ConfigurationDataValueName, float> values = 
        new Dictionary<ConfigurationDataValueName, float>();

    #endregion

    #region Properties

    /// <summary>
    /// Gets the amount player moves per second
    /// </summary>
    /// <value>player move units per second</value>
    public float PlayerMoveUnitsPerSecond
    {
        get { return values[ConfigurationDataValueName.PlayerMoveUnitsPerSecond]; }
    }

    /// <summary>
    /// Gets the amount bomb moves per second initially
    /// </summary>
    /// <value>bomb initial impulse force</value>
    public float BombInitialImpulseForce
    {
        get { return values[ConfigurationDataValueName.BombInitialImpulseForce]; }
    }

    /// <summary>
    /// Gets the amount bomb speeds up by
    /// </summary>
    /// <value>bomb speedup add force</value>
    public float BombSpeedupAddForce
    {
        get { return values[ConfigurationDataValueName.BombSpeedupAddForce]; }
    }

    /// <summary>
    /// Gets the minimum spawn time
    /// </summary>
    /// <value>minimum spawn time</value>
    public float MinSpawnTime
    {
        get { return values[ConfigurationDataValueName.MinSpawnTime]; }
    }

    /// <summary>
    /// Gets the maximum spawn time
    /// </summary>
    /// <value>maximum spawn time</value>
    public float MaxSpawnTime
    {
        get { return values[ConfigurationDataValueName.MaxSpawnTime]; }
    }

    /// <summary>
    /// Gets the time length of the first level
    /// </summary>
    /// <value>time length of first level</value>
    public int InitialLevelTimer
    {
        get { return (int)values[ConfigurationDataValueName.InitialLevelTimer]; }
    }

    /// <summary>
    /// Gets the amount of time added to the timer on a level up
    /// </summary>
    /// <value>amount of time added each level</value>
    public int LevelTimerIncrease
    {
        get { return (int)values[ConfigurationDataValueName.LevelTimerIncrease]; }
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Constructor
    /// Reads configuration data from a file. If the file read fails, the
    /// object contains default values for the configuration data
    /// </summary>
    public ConfigurationData()
    {
        // Read and save configuration data from file
        StreamReader input = null;
        try
        {
            // create stream reader object
            input = File.OpenText(Path.Combine(Application.streamingAssetsPath, 
                ConfigurationDataFileName));
            
            // populate values
            string currentLine = input.ReadLine();
            while(currentLine != null)
            {
                string[] split = currentLine.Split(',');
                ConfigurationDataValueName valueName = 
                    (ConfigurationDataValueName)Enum.Parse(
                        typeof(ConfigurationDataValueName), split[0]);
                values.Add(valueName, float.Parse(split[1]));
                currentLine = input.ReadLine();
            }
        }
        catch(Exception e)
        {
            // Set default values if issue with reading file
            Console.WriteLine(e.ToString());
            SetDefaultValues();
        }
        finally
        {
            // close input file
            if(input != null)
            {
                input.Close();
            }
        }
    }

    /// <summary>
    /// Set the configuration data to default values
    /// </summary>
    private void SetDefaultValues()
    {
        values.Clear();
        values.Add(ConfigurationDataValueName.PlayerMoveUnitsPerSecond, 10);
        values.Add(ConfigurationDataValueName.BombInitialImpulseForce, 5);
        values.Add(ConfigurationDataValueName.BombSpeedupAddForce, 1);
        values.Add(ConfigurationDataValueName.MinSpawnTime, 8);
        values.Add(ConfigurationDataValueName.MaxSpawnTime, 12);
        values.Add(ConfigurationDataValueName.InitialLevelTimer, 30);
        values.Add(ConfigurationDataValueName.LevelTimerIncrease, 5);
    }

    #endregion
}
