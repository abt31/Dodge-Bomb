using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBuilder : MonoBehaviour
{
    #region Fields

    // Prefabs
    [SerializeField] GameObject prefabPlayer;
    [SerializeField] GameObject prefabBomb;

    #endregion

    #region Methods

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        // Add player and first 3 bombs
        ThreeBombLayout();

        // Add listeners for events
        EventManager.AddLevelUpListener(LevelUp);
    }

    /// <summary>
    /// Rebuild game for new level
    /// </summary>
    /// <param name="level">next level</param>
    void LevelUp(int level)
    {
        // Destroy all current bombs
        GameObject[] bombs = GameObject.FindGameObjectsWithTag("Bomb");
        foreach(GameObject bomb in bombs)
        {
            Destroy(bomb);
        }
        Destroy(GameObject.FindGameObjectWithTag("Player"));

        SetLayout(level);
    }

    /// <summary>
    /// Set the layout for the next level
    /// </summary>
    /// <param name="level">next level</param>
    void SetLayout(int level)
    {
        if(level < 3)
        {
            ThreeBombLayout();
        }
        else if(level < 5)
        {
            FourBombLayout();
        }
        else if(level < 7)
        {
            SixBombLayout();
        }
        else
        {
            EightBombLayout();
        }
    }

    /// <summary>
    /// Layout with 3 bombs
    /// </summary>
    void ThreeBombLayout()
    {
        Instantiate(prefabPlayer);
        Instantiate(prefabBomb, new Vector2(-5, 0), Quaternion.identity);
        Instantiate(prefabBomb, new Vector2(5, 0), Quaternion.identity);
        Instantiate(prefabBomb, new Vector2(0, 2.5f), Quaternion.identity);
    }

    /// <summary>
    /// Layout with 4 bombs
    /// </summary>
    void FourBombLayout()
    {
        ThreeBombLayout();
        Instantiate(prefabBomb, new Vector2(0, -2.5f), Quaternion.identity);
    }

    /// <summary>
    /// Layout with 6 bombs
    /// </summary>
    void SixBombLayout()
    {
        FourBombLayout();
        Instantiate(prefabBomb, new Vector2(-5, -2.5f), Quaternion.identity);
        Instantiate(prefabBomb, new Vector2(5, 2.5f), Quaternion.identity);
    }

    /// <summary>
    /// Layout with 8 bombs
    /// </summary>
    void EightBombLayout()
    {
        SixBombLayout();
        Instantiate(prefabBomb, new Vector2(-5, 2.5f), Quaternion.identity);
        Instantiate(prefabBomb, new Vector2(5, -2.5f), Quaternion.identity);
    }

    #endregion
}
