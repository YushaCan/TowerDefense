using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    // Indicates the time
    public float globalTime = 0;
    // Indicates the spawn time for enemies
    [SerializeField]
    private float spawnTime = 3f;
    // Holds the position of the spawn point.
    public Transform spawnPoint;
    // This integer is for the enemy's count. If enemy's count reach certain amount of number, then the spawn time will be decrease.
    private int enemyCounter;


    private void Start()
    {
        enemyCounter = 0;
    }

    private void Update()
    {
        // If game is not over yet, spawn an enemy.
        if (!GameOver.isGameOver)
        {
            globalTime += Time.deltaTime;
            SpawnEnemy();
        }
    }

    // Enemy spawner function.
    void SpawnEnemy()
    {
        // Following 2 if statements is for the game spawn balancing.
        if(enemyCounter >= 10 && spawnTime > 1f)
        {
            enemyCounter = 0;
            spawnTime -= 0.25f;
        }

        if(enemyCounter >= 15 && spawnTime > 0.2)
        {
            enemyCounter = 0;
            spawnTime -= 0.1f;
        }
        // If game is active and spawn time has came, activate the enemy game object from pool.
        if(StartTheGame.isGameActive && globalTime >= spawnTime)
        {
            GameObject enemy = ObjectPooler.SharedInstance.GetPooledObjects();
            if(enemy != null)
            {
                // Spawn processes
                enemy.transform.position = spawnPoint.position;
                enemy.SetActive(true);
                enemyCounter++;
            }
            globalTime = 0;
        }
    }
}
