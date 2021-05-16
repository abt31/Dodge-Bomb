using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// A timer
/// </summary>
public class Timer : MonoBehaviour
{
    #region Fields

    // Timer execution support
    float duration = 0;
    float timeElapsed = 0;
    bool running = false;

    // Timer finished support
    bool started = false;
    TimerFinished timerFinished = new TimerFinished();

    #endregion

    #region Properties

    /// <summary>
    /// Sets the duration of the timer if timer isn't running
    /// </summary>
    /// <value>timer duration</value>
    public float Duration
    {
        set
        {
            if(!running)
            {
                duration = value;
            }
        }
    }

    /// <summary>
    /// Gets if timer has finished running
    /// The main use for this is to check if it's not finished
    /// </summary>
    /// <value>true if finished, false otherwise</value>
    public bool Finished
    {
        get { return started && !running; }
    }

    /// <summary>
    /// Gets time remaining on timer
    /// </summary>
    /// <value>seconds left</value>
    public float SecondsLeft
    {
        get
        {
            if(running)
            {
                return duration - timeElapsed;
            }
            else
            {
                return 0;
            }
        }
    }

    /// <summary>
    /// Gets time elapsed on timer
    /// </summary>
    /// <value>time elapsed</value>
    public float TimeElapsed
    {
        get
        {
            if(running)
            {
                return timeElapsed;
            }
            else
            {
                return 0;
            }
        }
    }

    #endregion

    #region Methods

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        // Update elapsed time until timer is finished
        if(running)
        {
            timeElapsed += Time.deltaTime;
            if(timeElapsed >= duration)
            {
                running = false;
                timerFinished.Invoke();
            }
        }
    }

    /// <summary>
    /// Start the timer if duration is greater than 0
    /// </summary>
    public void Run()
    {
        // Only run on valid duration
        if(duration > 0)
        {
            started = true;
            running = true;
            timeElapsed = 0;
        }
    }

    /// <summary>
    /// Stops the timer
    /// </summary>
    public void Stop()
    {
        started = false;
        running = false;
    }

    /// <summary>
    /// Add a listener for the timer finished event
    /// </summary>
    /// <param name="listener">listener</param>
    public void AddTimerFinishedListener(UnityAction listener)
    {
        timerFinished.AddListener(listener);
    }

    #endregion
}
