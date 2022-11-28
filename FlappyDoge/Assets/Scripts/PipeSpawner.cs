using System.Collections;
using UnityEngine;

public class PipeSpawner : GameOverBehavior
{
    /// <summary>
    /// The pipes prefab.
    /// </summary>
    public GameObject pipes;

    /// <summary>
    /// The delay between spawns.
    /// </summary>
    public float spawnInterval = 1f;

    /// <summary>
    /// The maximum position on the Y axis.
    /// </summary>
    public float maxPos = 0.4f;

    /// <summary>
    /// The minimum position on the Y axis.
    /// </summary>
    public float minPos = -0.25f;

    /// <summary>
    /// Continues to spawn while true.
    /// </summary>
    private bool _isSpawning = true;
    
    /// <summary>
    /// Starts the spawning routine.
    /// </summary>
    protected override void Start()
    {
        base.Start();
        manager.onGameStart += GameStart;
    }

    /// <summary>
    /// Starts spawning.
    /// </summary>
    private void GameStart()
    {
        StartCoroutine(SpawnRoutine());
        manager.onGameStart -= GameStart;
    }

    /// <summary>
    /// Spawns pipes.
    /// </summary>
    private IEnumerator SpawnRoutine()
    {
        while (_isSpawning == true)
        {
            Vector3 position = transform.position + Vector3.up * Random.Range(minPos, maxPos);
            Instantiate(pipes, position, Quaternion.identity, transform);

            // Waits until a set amount of time has passed.
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    /// <summary>
    /// Stops spawning objects.
    /// </summary>
    protected override void GameOver()
    {
        base.GameOver();
        _isSpawning = false;
    }
}
