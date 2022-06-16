using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Indicates the speed of bullet
    [SerializeField]
    private float bulletSpeed = 5f;

    public Enemy enemy;

    private void Update()
    {
        // Bullet searchs the closest enemy
        FindClosestEnemy();
    }

    // This function allows bullet to find closest enemy.
    void FindClosestEnemy()
    {
        // Calculates the distance between enemy and bullet game object 
        float distanceToClosestEnemy = Mathf.Infinity;
        // Indicates the closest enemy
        Enemy closestEnemy = null;
        // Finds all gameobjects which types are "Enemy"
        Enemy[] allEnemies = GameObject.FindObjectsOfType<Enemy>();
        
        // All the main processes are in this foreach loop
        foreach(Enemy currentEnemy in allEnemies)
        {
            float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
            if(distanceToEnemy < distanceToClosestEnemy)
            {
                distanceToClosestEnemy = distanceToEnemy;
                closestEnemy = currentEnemy;
            }
        }
        Debug.DrawLine(this.transform.position, closestEnemy.transform.position);
        // Make the bullets follow the enemy
        transform.position = Vector2.MoveTowards(transform.position, closestEnemy.transform.position, bulletSpeed * Time.deltaTime);
    }


    // Destroy bullet if the bullet collide with the enemy.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }

    //Destroy bullet if bullet reaches the range of a turret
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Turret"))
        {
            Destroy(gameObject);
        }
    }
}
