using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // For the path. When enemy dies, with this script enemy's waypoint set to zero.
    public FollowThePath pathWay;
    // All scriptable objects
    public EnemyData enemySpecs;
    public TowerData basicTowerSpecs;
    public TowerData powerfulTowerSpecs;
    // Indicates wheter enemy game object is active or not.
    public bool isActive;

    [SerializeField]
    public int enemyHealth;
    [SerializeField]
    private int basicTowerShootPower;
    [SerializeField]
    private int powerfulTowerShootPower;

    void Start()
    {
        // Get the values of  scriptable objects and set them to a variable.
        enemyHealth = enemySpecs.health;
        basicTowerShootPower = basicTowerSpecs.shootPower;
        powerfulTowerShootPower = powerfulTowerSpecs.shootPower;
    }

    // When enemy is enabled, turn the isActive boolean to true. (For the turrets)
    private void OnEnable()
    {
        isActive = true;
    }

    // When enemy is disabled, turn the isActive boolean to false. And do the other lines for the turrets to not stay awake.
    private void OnDisable()
    {      
        isActive = false;
        FindClosestTurret();
    }

    // Take damage when bullet and enemy collide.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            TakeDamage();         
        } 
        else if (collision.gameObject.CompareTag("RedBullet"))
        {
            TakeDamageRed();
        }
    }

    // Calculate the damage of the NORMAL bullet
    void TakeDamage()
    {
        enemyHealth -= basicTowerShootPower;
        if (enemyHealth <= 0)
        {
            // Increase kill count for the counter
            KillCounter.killCount++;
            // This boolean controls the enemy's path. If it is dead then the waypoint of enemy is set to 0
            pathWay.isDead = true; 
            gameObject.SetActive(false);
            enemyHealth = enemySpecs.health;
        }
    }

    // Calculate the damage of the RED bullet
    void TakeDamageRed()
    {
        enemyHealth -= powerfulTowerShootPower;
        if (enemyHealth <= 0)
        {
            // Increase kill count for the counter
            KillCounter.killCount++;
            // This boolean controls the enemy's path. If it is dead then the waypoint of enemy is set to 0
            pathWay.isDead = true;
            gameObject.SetActive(false);
            enemyHealth = enemySpecs.health;
        }
    }


    void FindClosestTurret()
    {
        float distanceToClosestTurret = Mathf.Infinity;
        Turret closestTurret = null;
        Turret[] allTurrets = GameObject.FindObjectsOfType<Turret>();

        foreach (Turret currentTurret in allTurrets)
        {
            float distanceToEnemy = (currentTurret.transform.position - this.transform.position).sqrMagnitude;
            if (distanceToEnemy < distanceToClosestTurret)
            {
                distanceToClosestTurret = distanceToEnemy;
                closestTurret = currentTurret;
            }
        }
        // This 3 lines prevent to a bug which makes turrets to stay awake all the time
        closestTurret.isDetected = false;
        closestTurret.alarm.GetComponent<SpriteRenderer>().color = Color.green;

        Debug.DrawLine(this.transform.position, closestTurret.transform.position);
    }
}
