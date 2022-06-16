using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    // For indicate the enemy.
    public Enemy enemy;
    // Controls wheter an enemy enters it's border.
    public bool isDetected = false;
    // Rings the alarm.
    public GameObject alarm;
    // Just for the gun of the turret
    public GameObject gun;
    // For the bullet spawn
    public GameObject bullet;
    // Indicates the fire rate of the tower
    private float fireRate;

    private float nextTimeToShoot = 0f;
    // Indicates the spawn point of the bullet
    public Transform shootPoint;

    private void Start()
    {
        fireRate = 0.25f;
        nextTimeToShoot = Time.time;
    }
    private void Update()
    {
        // If game is not over, then find the closest enemy and shoot!
        if (!GameOver.isGameOver)
        {
            FindClosestEnemy();
            TimeToShoot();
        }
    }
    // If an enemy enters the sight of the turret. Turret's sirens are activated.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !isDetected)
        {
            isDetected = true;
            alarm.GetComponent<SpriteRenderer>().color = Color.red;
        }
        else if(collision.gameObject.CompareTag("Enemy") && isDetected)
        {
            isDetected = false;
            alarm.GetComponent<SpriteRenderer>().color = Color.green;
        }
    }
    // If it is time to shoot and the enemy has already detected, then shoot!
    private void TimeToShoot()
    {
        if(Time.time > nextTimeToShoot && isDetected)
        {
            Instantiate(bullet, shootPoint.position, Quaternion.identity);
            nextTimeToShoot = Time.time + fireRate;
        }
    }
    // Finds the closest enemy to shoot.
    void FindClosestEnemy()
    {
        // If enemy gameobject is active then calculate the closest enemy
        if (enemy.isActive)
        {
            float distanceToClosestEnemy = Mathf.Infinity;
            Enemy closestEnemy = null;
            Enemy[] allEnemies = GameObject.FindObjectsOfType<Enemy>();

            foreach (Enemy currentEnemy in allEnemies)
            {
                float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
                if (distanceToEnemy < distanceToClosestEnemy)
                {
                    distanceToClosestEnemy = distanceToEnemy;
                    closestEnemy = currentEnemy;
                }
            }
            Debug.DrawLine(this.transform.position, closestEnemy.transform.position);
        }
        
    }
}
