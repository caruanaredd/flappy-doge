using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : GameOverBehavior
{
    [Header("Links")]
    public ScoreManager scoreManager;
    
    /// <summary>
    /// The flapping force.
    /// </summary>
    [Header("Gameplay")]
    public float force = 2f;

    /// <summary>
    /// The rotation modifier making turning more accurate.
    /// </summary>
    public float rotationModifier = 5f;
    
    /// <summary>
    /// The minimum rotation the sprite may have.
    /// </summary>
    public float minAngle = -90f;

    /// <summary>
    /// The maximum rotation the sprite may have.
    /// </summary>
    public float maxAngle = 45f;

    /// <summary>
    /// Will flip to true when the game starts.
    /// </summary>
    private bool _isPlaying = false;
    
    /// <summary>
    /// Determines whether the player is alive.
    /// </summary>
    private bool _isAlive = true;

    /// <summary>
    /// The player's physics component.
    /// </summary>
    private Rigidbody2D _rigidbody;

    /// <summary>
    /// Associates the script components.
    /// </summary>
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Updates the sprite rotation.
    /// </summary>
    private void FixedUpdate()
    {
        float rotation = Mathf.Clamp(_rigidbody.velocity.y * rotationModifier, minAngle, maxAngle);
        _rigidbody.MoveRotation(rotation);
    }

    /// <summary>
    /// Adds a point when this object enters a trigger.
    /// </summary>
    /// <param name="col">The other collider.</param>
    private void OnTriggerEnter2D(Collider2D col)
    {
        // We don't need to check for a tag if the only thing we're overlapping
        // is the middle of the pipes.
        if (!scoreManager) return;
        scoreManager.AddPoint();
    }

    /// <summary>
    /// Ends the game on collision.
    /// </summary>
    /// <param name="collision">The collision data.</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        _isAlive = false;
        _rigidbody.MoveRotation(-90);
        
        manager.GameOver();
        
        enabled = false;
    }

    /// <summary>
    /// Handles the flap mechanic.
    /// </summary>
    private void OnFlap()
    {
        // If we haven't started playing the game, start things off.
        if (_isPlaying == false)
        {
            manager.StartGame();
        }
        
        // This line cancels out the function if the player dies.
        if (_isAlive == false) return;
        
        _rigidbody.velocity = Vector2.up * force;
    }
}
