using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField][Range(0f, 5f)] float fireRate;
    [SerializeField] float fireRange;
    [SerializeField] private Bullet bulletPrefab;

    private float lastShoot;


    // GAME //-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-
    private void Update()
    {
        Shoot();
    }


    // FUNCTIONS //-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-
    public GameObject FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject nearestEnemy = null;
        float enemyDistance;
        float minDistance = fireRange;

        foreach (var enemy in enemies)
        {
            // Calculate the distance between the Player and a Enemy
            enemyDistance = Vector2.Distance(enemy.transform.position, transform.position);

            if (enemyDistance < minDistance)
            {
                // Found it
                nearestEnemy = enemy;
                // Change the minimum distace egual to the nearest enemy
                minDistance = enemyDistance;
            }
        }
        return nearestEnemy;
    }


    public void Shoot()
    {
        GameObject nearEnemy = FindNearestEnemy();

        if (nearEnemy)
        {
            if (Time.time - lastShoot > fireRate)
            {
                lastShoot = Time.time;

                // Spawn a bullet in the player position
                Bullet bul = Instantiate(bulletPrefab);
                bul.transform.position = transform.position;

                // Direct the bullet against the enemy
                Vector2 direction = (nearEnemy.transform.position - transform.position).normalized;
                bul.SetUp(direction);
            }
        }
    }
}
