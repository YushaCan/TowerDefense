using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowThePath : MonoBehaviour
{
    // Array of waypoints to walk from one to the next one
    [SerializeField]
    private Transform[] waypoints;
    //For enemy movement speed
    public EnemyData enemy;
    // Checks the game object, this script attached to. (Enemy)
    public bool isDead = false;
    // For the path of the enemy.
    public int waypointIndex = 0;

    private void Update()
    {
        // Allows to move enemy if the game is not over.
        if (!GameOver.isGameOver)
        {
            Move();
        }
    }

    // Move function
    private void Move()
    {
        // If the object is dead, then set it's waypoint to zero. (Spawn point)
        if (isDead)
        {
            waypointIndex = 0;
            isDead = false;
        }

        // If enemy doesn't reached last waypoint then it moves
        if (waypointIndex <= waypoints.Length - 1)
        {
            // Move Enemy from current waypoint to the next one
            transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, enemy.movementSpeed * Time.deltaTime);

            // If Enemy reaches position of waypoint he walked towards then waypointIndex is increased by 1 and Enemy starts to walk to the next waypoint
            if (transform.position == waypoints[waypointIndex].transform.position)
            {
                waypointIndex += 1;
            }

            // If enemy reached last waypoint THE GAME IS OVER!
            if (waypointIndex == waypoints.Length)
            {
                GameOver.isGameOver = true;
                gameObject.SetActive(false);
            }
        }
    }
}
