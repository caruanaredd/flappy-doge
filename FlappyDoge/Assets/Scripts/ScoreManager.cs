using System;
using TMPro;
using UnityEngine;

public class ScoreManager : GameOverBehavior
{
    /// <summary>
    /// The current score.
    /// </summary>
    private static int _score = 0;

    /// <summary>
    /// The game's high score.
    /// </summary>
    private static int _highScore = 0;

    /// <summary>
    /// Whether or not the high score was beaten this game.
    /// </summary>
    private static bool _newHighScore = false;
    
    /// <summary>
    /// The game score.
    /// </summary>
    public TextMeshProUGUI scoreText;

    /// <summary>
    /// The scoreboard object.
    /// </summary>
    public Scoreboard scoreboard;

    /// <summary>
    /// Resets the score.
    /// </summary>
    protected override void Start()
    {
        base.Start();
        
        _score = 0;
        _newHighScore = false;
    }

    /// <summary>
    /// Shows the score board when the game is over.
    /// </summary>
    protected override void GameOver()
    {
        base.GameOver();
        
        ShowScoreboard();
        enabled = false;
    }

    /// <summary>
    /// Adds a point to the score.
    /// </summary>
    public void AddPoint()
    {
        _score++;

        if (_highScore < _score)
        {
            _highScore = _score;
            _newHighScore = true;
        }
        
        UpdateScoreText();
    }

    /// <summary>
    /// Shows the scoreboard.
    /// </summary>
    private void ShowScoreboard()
    {
        if (!scoreboard) return;
        scoreboard.Show(_score, _highScore, _newHighScore);
    }

    /// <summary>
    /// Updates the score UI.
    /// </summary>
    private void UpdateScoreText()
    {
        if (!scoreText) return;
        scoreText.text = _score.ToString();
    }
}