using System;
using UnityEngine;

public class Ground : GameOverBehavior
{
    /// <summary>
    /// The animator component.
    /// </summary>
    private Animator _animator;

    /// <summary>
    /// Identifies and sets the Animator component.
    /// </summary>
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    /// <summary>
    /// Sets the animation speed.
    /// </summary>
    protected override void Start()
    {
        base.Start();
        _animator.SetFloat("Speed", manager.speed);
    }

    /// <summary>
    /// Updates the animator state.
    /// </summary>
    protected override void GameOver()
    {
        base.GameOver();
        _animator.SetFloat("Speed", 0);
    }
}
