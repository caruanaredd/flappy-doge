using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{
    /// <summary>
    /// The score text.
    /// </summary>
    public TextMeshProUGUI scoreLabel;

    /// <summary>
    /// The high score text.
    /// </summary>
    public TextMeshProUGUI highScoreLabel;

    /// <summary>
    /// The new high score object.
    /// </summary>
    public GameObject newHighScoreObject;

    /// <summary>
    /// The medal image.
    /// </summary>
    public Image medalImage;
    
    [Header("Medals")]
    public Sprite noMedal;
    public Sprite bronzeMedal;
    public Sprite silverMedal;
    public Sprite goldMedal;

    /// <summary>
    /// Shows the scoreboard.
    /// </summary>
    /// <param name="score">The current score.</param>
    /// <param name="highScore">The high score.</param>
    /// <param name="newHighScore">Whether or not the player set a new high score.</param>
    public void Show(int score, int highScore, bool newHighScore)
    {
        scoreLabel.text = score.ToString();
        highScoreLabel.text = highScore.ToString();
        newHighScoreObject.SetActive(newHighScore);
        
        SetMedal(highScore);

        gameObject.SetActive(true);
    }

    /// <summary>
    /// Sets the medal image.
    /// </summary>
    /// <param name="score">The score to consider.</param>
    private void SetMedal(float score)
    {
        if (score >= 50)
        {
            medalImage.sprite = goldMedal;
        }
        else if (score >= 25)
        {
            medalImage.sprite = silverMedal;
        }
        else if (score >= 10)
        {
            medalImage.sprite = bronzeMedal;
        }
        else
        {
            medalImage.sprite = noMedal;
        }
    }
}