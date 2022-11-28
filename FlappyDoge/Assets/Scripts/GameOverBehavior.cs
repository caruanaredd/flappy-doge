using UnityEngine;

/// <summary>
/// This class is only meant to give basic functionality to
/// other scripts, so we don't need to repeat much code.
/// </summary>
public abstract class GameOverBehavior : MonoBehaviour
{
    
    /// <summary>
    /// <para>
    /// The stored instance of the game manager.
    /// </para>
    /// <para>
    /// Protected so that inherited classes may be able to use it.
    /// </para>
    /// </summary>
    protected GameManager manager;

    /// <summary>
    /// Binds the Game Over function to the Game Manager.
    /// </summary>
    protected virtual void Start()
    {
        manager = FindObjectOfType<GameManager>();
        
        // Link the Game over function.
        manager.onGameOver += GameOver;
    }

    /// <summary>
    /// The basic Game Over functionality.
    /// </summary>
    protected virtual void GameOver()
    {
        // Cleans up the Game Over link.
        manager.onGameOver -= GameOver;
    }
}