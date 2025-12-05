using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Enemy
{
    // COLLISION //--------------------------------------------------------
    protected override void OnCollisionEnter2D(Collision2D other)
    {
        if (Time.time - lastAttack > wait)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Debug.Log($"{other.gameObject.name} take {damage} damages");
                Life life = other.gameObject.GetComponent<Life>();
                life.TakeDamage(damage);

                Destroy(gameObject);
            }
        }
    }

}
