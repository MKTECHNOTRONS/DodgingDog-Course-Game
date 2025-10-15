using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstacle;
    public float spawnRate = 2f;     // Time between spawns
    public float maxXPos = 2.5f;     // Horizontal spawn limit

    void Start()
    {
        // Start spawning obstacles automatically
        InvokeRepeating("Spawn", 1f, spawnRate);
    }

    void Spawn()
    {
        float randomX = Random.Range(-maxXPos, maxXPos);
        Vector2 spawnPos = new Vector2(randomX, transform.position.y);
        Instantiate(obstacle, spawnPos, Quaternion.identity);
    }

    public void StopSpawing()
    {
        CancelInvoke("Spawn");
    }
}
