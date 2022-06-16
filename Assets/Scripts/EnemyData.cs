using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Enemy")]
public class EnemyData : ScriptableObject
{
    public string name;
    public int health;
    public float movementSpeed;
    public GameObject enemyObject;
}
