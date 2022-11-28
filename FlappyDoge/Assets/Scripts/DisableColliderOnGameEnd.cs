using UnityEngine;

public class DisableColliderOnGameEnd : GameOverBehavior
{
    /// <summary>
    /// The collider attached to this object.
    /// </summary>
    private Collider2D _collider;

    /// <summary>
    /// Loads the collider.
    /// </summary>
    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
    }

    /// <summary>
    /// Disables the collider on game end.
    /// </summary>
    protected override void GameOver()
    {
        base.GameOver();
        
        if (_collider)
        {
            _collider.enabled = false;
        }
    }
}
