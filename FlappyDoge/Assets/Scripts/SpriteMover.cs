using UnityEngine;

public class SpriteMover : GameOverBehavior
{
    /// <summary>
    /// A cached version of the GameManager speed.
    /// </summary>
    private float _speed;

    /// <summary>
    /// Sets the object speed.
    /// </summary>
    protected override void Start()
    {
        base.Start();
        _speed = manager.speed;
    }

    /// <summary>
    /// Updates the sprite position.
    /// </summary>
    private void Update()
    {
        // Calculate the deltaTime.
        float t = _speed * Time.deltaTime;
        transform.Translate(Vector3.left * t);

        // Destroy the GameObject if it is out of bounds.
        if (transform.position.x < -5f)
        {
            manager.onGameOver -= GameOver;
            Destroy(gameObject);
        }
    }

    protected override void GameOver()
    {
        base.GameOver();
        enabled = false;
    }
}
