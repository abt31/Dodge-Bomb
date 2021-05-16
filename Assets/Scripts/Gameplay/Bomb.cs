using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A bomb object
/// </summary>
public class Bomb : MonoBehaviour
{
    #region Fields

    // Movement support
    Rigidbody2D rb2d;
    Timer moveTimer;

    // Speedup support
    Timer speedupTimer;
    float currentSpeed;

    #endregion

    #region Methods

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        // Initialize fields
        rb2d = GetComponent<Rigidbody2D>();
        currentSpeed = ConfigurationUtils.BombInitialImpulseForce;

        // Start move timer
        moveTimer = gameObject.AddComponent<Timer>();
        moveTimer.Duration = 1;
        moveTimer.AddTimerFinishedListener(HandleMoveTimerFinished);
        moveTimer.Run();

        // Start speedup timer
        speedupTimer = gameObject.AddComponent<Timer>();
        speedupTimer.Duration = 10;
        speedupTimer.AddTimerFinishedListener(HandleSpeedupTimerFinished);
        speedupTimer.Run();
    }

    /// <summary>
    /// Apply impulse force to move Bomb at random angle
    /// </summary>
    void StartMoving()
    {
        float angle = Random.Range(0, 360);
        Vector2 moveDirection = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        rb2d.AddForce(moveDirection * currentSpeed, 
            ForceMode2D.Impulse);
    }

    /// <summary>
    /// Executes when the move timer finishes
    /// </summary>
    void HandleMoveTimerFinished()
    {
        moveTimer.Stop();
        StartMoving();
    }

    /// <summary>
    /// Executes when the speedup timer finishes
    /// </summary>
    void HandleSpeedupTimerFinished()
    {
        speedupTimer.Stop();
        Vector2 moveDirection = rb2d.velocity.normalized;
        currentSpeed += ConfigurationUtils.BombSpeedupAddForce;
        rb2d.velocity = Vector3.zero;
        rb2d.AddForce(moveDirection * currentSpeed, ForceMode2D.Impulse);
        speedupTimer.Run();
    }

    #endregion
}
