using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float speed;

    // The distance when the Enemy start to catch the Player
    [SerializeField] protected float maxDistance;
    protected PlayerMove player;
    protected float playerDistance;

    // The damage, and a waiting time, to avoid accidental multiple damage
    [SerializeField] protected int damage;
    protected float wait = 0.1f;
    protected float lastAttack = -1f;



    // GAME //-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-
    protected void Awake()
    {
        player = FindAnyObjectByType<PlayerMove>();
    }

    protected void FixedUpdate()
    {
        EnemyMovement();
    }


    // COLLISION //--------------------------------------------------------
    protected virtual void OnCollisionEnter2D(Collision2D other)
    {
        if (Time.time - lastAttack > wait)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Debug.Log($"{other.gameObject.name} take {damage} damages");
                Life life = other.gameObject.GetComponent<Life>();
                life.TakeDamage(damage);
            }
        }
    }

    protected void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player")) lastAttack = Time.time;
    }


    // FUNCTIONS //-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-
    public void EnemyMovement()
    {
        if (player != null)
        {
            playerDistance = Vector2.Distance(player.transform.position, transform.position);
            if (playerDistance < maxDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            }  
        }
    }
}
