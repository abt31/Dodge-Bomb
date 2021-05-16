using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// A bomb spawner
/// </summary>
public class BombSpawner : MonoBehaviour
{
    #region Fields

    // Spawn support
    [SerializeField] GameObject prefabBomb;
    Timer spawnTimer;
    float radius;
    float spawnRange;
    float spawnLocationMinX = -5;
    float spawnLocationMaxX = 5;
    float spawnLocationMinY = -2.5f;
    float spawnLocationMaxY = 2.5f;
    bool retrySpawn = false;

    // Overlap check support
    Vector2 overlapCheckMin;
    Vector2 overlapCheckMax;

    #endregion

    #region Methods

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        // Save radius
        GameObject temp = Instantiate(prefabBomb, new Vector3
            (0, 0, -Camera.main.transform.position.z), Quaternion.identity);
        CircleCollider2D cc2d = temp.GetComponent<CircleCollider2D>();
        radius = cc2d.radius;
        Destroy(temp);

        // Start spawn timer
        spawnRange = ConfigurationUtils.MaxSpawnTime - ConfigurationUtils.MinSpawnTime;
        spawnTimer = gameObject.AddComponent<Timer>();
        spawnTimer.Duration = GetSpawnDelay();
        spawnTimer.AddTimerFinishedListener(HandleSpawnTimerFinished);
        spawnTimer.Run();
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        // Try another spawn if pending
        if(retrySpawn)
        {
            SpawnBomb();
        }
    }

    /// <summary>
    /// Spawn a new bomb
    /// </summary>
    void SpawnBomb()
    {
        float x = spawnLocationMinX + Random.value * (spawnLocationMaxX * 2);
        float y = spawnLocationMinY + Random.value * (spawnLocationMaxY * 2);

        // Calculate overlap check min and max
        overlapCheckMin = new Vector2(x - radius, y - radius);
        overlapCheckMax = new Vector2(x + radius, y + radius);

        // Check for overlap
        if(Physics2D.OverlapArea(overlapCheckMin, overlapCheckMax) == null)
        {
            retrySpawn = false;
            GameObject bomb = GameObject.FindGameObjectWithTag("Bomb");
            Instantiate(prefabBomb, new Vector3(x, y, -Camera.main.transform.position.z), Quaternion.identity);
        }
        else
        {
            retrySpawn = true;
        }
    }

    /// <summary>
    /// Calculate a random spawn delay
    /// </summary>
    /// <returns>random spawn delay</returns>
    float GetSpawnDelay()
    {
        return ConfigurationUtils.MinSpawnTime + UnityEngine.Random.value * spawnRange;
    }

    /// <summary>
    /// Spawn bomb when the spawn timer finishes
    /// </summary>
    void HandleSpawnTimerFinished()
    {
        retrySpawn = false;
        SpawnBomb();
        spawnTimer.Duration = GetSpawnDelay();
        spawnTimer.Run();
    }

    #endregion
}
