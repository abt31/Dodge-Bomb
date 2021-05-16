using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    /// <summary>
    /// Awake is called before Start
    /// </summary>
    void Awake()
    {
        // initialize screen utils and configuration utils
        ScreenUtils.Initialize();
        ConfigurationUtils.Initialize();
    }
}
