using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    // For Singleton instance
    public static ObjectPooler SharedInstance;
    // List of the pooled gameobjects
    public List<GameObject> pooledObjects;
    // Pooled enemy's scriptable objects
    public EnemyData objectToPool;
    public EnemyData objectToPool_Mid;
    public EnemyData objectToPool_High;

    public int amountToPool;
    private void Awake()
    {
        // For Singleton design pattern.
        SharedInstance = this;
    }
    private void Start()
    {
        // 3 types of enemies are added to pool
        pooledObjects = new List<GameObject>();
        for(int i = 0; i < amountToPool / 3; i++)
        {
            GameObject obj = Instantiate(objectToPool.enemyObject);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
        for(int j = amountToPool / 3; j < (amountToPool / 3) * 2; j++)
        {
            GameObject obj = Instantiate(objectToPool_Mid.enemyObject);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
        for (int k = (amountToPool / 3) * 2; k < amountToPool; k++)
        {
            GameObject obj = Instantiate(objectToPool_High.enemyObject);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledObjects()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        return null;
    }
}
