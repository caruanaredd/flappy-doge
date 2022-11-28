using UnityEngine;

public class OnLevelLoad : MonoBehaviour
{
    /// <summary>
    /// The intro screen UI.
    /// </summary>
    public GameObject introUI;

    /// <summary>
    /// The gameplay UI.
    /// </summary>
    public GameObject gameplayUI;

    /// <summary>
    /// The Game Manager instance.
    /// </summary>
    private GameManager _manager;
    
    /// <summary>
    /// Tells the game manager to wait.
    /// </summary>
    private void Start()
    {
        // When this script loads, it tells the Game Manager
        // to wait for the game to start.
        _manager = FindObjectOfType<GameManager>();

        _manager.onGameStart += GameStart;
        _manager.PauseTime();
    }

    /// <summary>
    /// Switches the UI once the GameManager starts the game.
    /// </summary>
    private void GameStart()
    {
        // Disable the intro UI.
        if (introUI)
        {
            introUI.SetActive(false);
        }

        // Enable the gameplay UI.
        if (gameplayUI)
        {
            gameplayUI.SetActive(true);
        }

        // Unlink the function.
        _manager.onGameStart -= GameStart;
        
        // Turn off this script.
        enabled = false;
    }
}
