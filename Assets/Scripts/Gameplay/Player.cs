using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// The playable character
/// </summary>
public class Player : MonoBehaviour
{
    #region Fields

    // Movement support
    Rigidbody2D rb2d;
    
    // Clamp support
    float radius;

    // Change sprite support
    [SerializeField] Sprite[] sprites = new Sprite[8];
    SpriteRenderer spriteRenderer;

    // Event support
    PlayerDied playerDied;

    #endregion

    #region Methods

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        // Initialize fields
        rb2d = GetComponent<Rigidbody2D>();
        radius = GetComponent<CircleCollider2D>().radius;
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Initialize event and add class as invoker
        playerDied = new PlayerDied();
        EventManager.AddPlayerDiedInvoker(this);
    }

    /// <summary>
    /// Update for physics based actions
    /// </summary>
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Move player horizontally
        if(horizontalInput != 0 && verticalInput == 0)
        {
            Vector2 position = rb2d.position;
            position.x += horizontalInput * 
                ConfigurationUtils.PlayerMoveUnitsPerSecond * Time.deltaTime;
            position.x = CalculateClampedX(position.x);
            
            // Change sprite based on direction
            if(horizontalInput > 0 && spriteRenderer.sprite != sprites[4])
            {
                spriteRenderer.sprite = sprites[4];
            }
            else if(horizontalInput < 0 && spriteRenderer.sprite != sprites[3])
            {
                spriteRenderer.sprite = sprites[3];
            }
            
            rb2d.MovePosition(position);
        }
        // Move player vertically
        else if(verticalInput != 0 && horizontalInput == 0)
        {
            Vector2 position = rb2d.position;
            position.y += verticalInput * 
                ConfigurationUtils.PlayerMoveUnitsPerSecond * Time.deltaTime;
            position.y = CalculateClampedY(position.y);
            
            // Change sprite based on direction
            if(verticalInput > 0 && spriteRenderer.sprite != sprites[5])
            {
                spriteRenderer.sprite = sprites[5];
            }
            else if(verticalInput < 0 && spriteRenderer.sprite != sprites[0])
            {
                spriteRenderer.sprite = sprites[0];
            }
            
            rb2d.MovePosition(position);
        }
        // Move player diagonally
        else if(horizontalInput != 0 && verticalInput != 0)
        {
            // Divide x and y components by Sqrt(2) to keep diagonal movements at the same speed
            Vector2 position = rb2d.position;
            position.x += horizontalInput * 
                ConfigurationUtils.PlayerMoveUnitsPerSecond / 
                Mathf.Sqrt(2) * Time.deltaTime;
            position.x = CalculateClampedX(position.x);
            position.y += verticalInput * 
                ConfigurationUtils.PlayerMoveUnitsPerSecond / 
                Mathf.Sqrt(2) * Time.deltaTime;
            position.y = CalculateClampedY(position.y);
            
            // Change sprite based on direction
            if(horizontalInput > 0 && verticalInput > 0 && 
                spriteRenderer.sprite != sprites[7])
            {
                spriteRenderer.sprite = sprites[7];
            }
            else if(horizontalInput > 0 && verticalInput < 0 &&
                spriteRenderer.sprite != sprites[2])
            {
                spriteRenderer.sprite = sprites[2];
            }
            else if(horizontalInput < 0 && verticalInput > 0 &&
                spriteRenderer.sprite != sprites[6])
            {
                spriteRenderer.sprite = sprites[6];
            }
            else if(horizontalInput < 0 && verticalInput < 0 &&
                spriteRenderer.sprite != sprites[1])
            {
                spriteRenderer.sprite = sprites[1];
            }

            rb2d.MovePosition(position);
        }
    }

    /// <summary>
    /// Calculate the position to keep player from going 
    /// off the left/right screen edges
    /// </summary>
    /// <param name="x">x position</param>
    /// <returns>clamped x position</returns>
    float CalculateClampedX(float x)
    {
        if(x - radius < ScreenUtils.ScreenLeft)
        {
            x = ScreenUtils.ScreenLeft + radius;
        }
        else if(x + radius > ScreenUtils.ScreenRight)
        {
            x = ScreenUtils.ScreenRight - radius;
        }
        return x;
    }

    /// <summary>
    /// Calculate the position to keep player from going
    /// of the top/bottom screen edges
    /// </summary>
    /// <param name="y">y position</param>
    /// <returns>clamped y position</returns>
    float CalculateClampedY(float y)
    {
        if(y - radius < ScreenUtils.ScreenBottom)
        {
            y = ScreenUtils.ScreenBottom + radius;
        }
        else if(y + radius > ScreenUtils.ScreenTop)
        {
            y = ScreenUtils.ScreenTop - radius;
        }
        return y;
    }

    /// <summary>
    /// Called when hit by a bomb
    /// </summary>
    /// <param name="collision">an object that collided with player</param>
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Bomb"))
        {
            // Destroy bomb and player
            Destroy(collision.gameObject);
            Destroy(gameObject);

            // Invoke player died event
            playerDied.Invoke();
        }
    }

    /// <summary>
    /// Listener for player died event
    /// </summary>
    /// <param name="listener">listener for player died event</param>
    public void AddPlayerDiedListener(UnityAction listener)
    {
        playerDied.AddListener(listener);
    }

    #endregion
}
