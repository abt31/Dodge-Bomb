using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides screen utilities
/// </summary>
public static class ScreenUtils
{
    #region Fields

    // resolution change support
    static int screenWidth;
    static int screenHeight;

    // boundary check support
    static float screenLeft;
    static float screenRight;
    static float screenTop;
    static float screenBottom;

    #endregion

    #region Properties

    /// <summary>
    /// Gets left edge of the screen
    /// </summary>
    /// <value>left edge of the screen</value>
    public static float ScreenLeft
    {
        get
        {
            CheckScreenSizeChanged();
            return screenLeft;
        }
    }

    /// <summary>
    /// Gets right edge of the screen
    /// </summary>
    /// <value>right edge of the screen</value>
    public static float ScreenRight
    {
        get
        {
            CheckScreenSizeChanged();
            return screenRight;
        }
    }

    /// <summary>
    /// Gets top edge of the screen
    /// </summary>
    /// <value>top edge of the screen</value>
    public static float ScreenTop
    {
        get
        {
            CheckScreenSizeChanged();
            return screenTop;
        }
    }

    /// <summary>
    /// Gets bottom edge of the screen
    /// </summary>
    /// <value>bottom edge of the screen</value>
    public static float ScreenBottom
    {
        get
        {
            CheckScreenSizeChanged();
            return screenBottom;
        }
    }

    #endregion

    #region Methods

    /// <summary>
    /// Initializes screen utilities
    /// </summary>
    public static void Initialize()
    {
        // Save screen width/height for resolution changes
        screenWidth = Screen.width;
        screenHeight = Screen.height;

        // Save screen edges
        float screenZ = -Camera.main.transform.position.z;
        Vector3 lowerLeftCornerScreen = new Vector3(0, 0, screenZ);
        Vector3 upperRightCornerScreen = 
            new Vector3(screenWidth, screenHeight, screenZ);
        Vector3 lowerLeftCornerWorld = 
            Camera.main.ScreenToWorldPoint(lowerLeftCornerScreen);
        Vector3 upperRightCornerWorld = 
            Camera.main.ScreenToWorldPoint(upperRightCornerScreen);
        screenLeft = lowerLeftCornerWorld.x;
        screenBottom = lowerLeftCornerWorld.y;
        screenRight = upperRightCornerWorld.x;
        screenTop = upperRightCornerWorld.y;
    }

    /// <summary>
    /// Check for change in screen size
    /// </summary>
    private static void CheckScreenSizeChanged()
    {
        if(screenWidth != Screen.width || screenHeight != Screen.height)
        {
            Initialize();
        }
    }

    #endregion
}
