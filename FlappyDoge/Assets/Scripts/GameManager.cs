using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// The game speed.
    /// </summary>
    public float speed = 1f;
    
    /// <summary>
    /// An open-ended function that other scripts can bind their
    /// functionality to.
    /// </summary>
    public UnityAction onGameOver;

    /// <summary>
    /// An open-ended function that other scripts can bind their
    /// functionality to.
    /// </summary>
    public UnityAction onGameStart;

    /// <summary>
    /// Stops time until the first flap is made.
    /// </summary>
    public void PauseTime()
    {
        Time.timeScale = 0;
    }

    /// <summary>
    /// Starts the game.
    /// </summary>
    public void StartGame()
    {
        Time.timeScale = 1;

        if (onGameStart != null)
        {
            onGameStart.Invoke();
        }
    }

    /// <summary>
    /// Stops the game.
    /// </summary>
    public void GameOver()
    {
        if (onGameOver != null)
        {
            onGameOver();
        }
    }
}
