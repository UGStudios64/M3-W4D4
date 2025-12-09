using UnityEngine;

public class Bomb : Enemy
{
    private Life bombLife;


    // GAME //-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-
    private void Start()
    {
        bombLife = GetComponent<Life>();
    }


    // COLLISION //--------------------------------------------------------
    protected override void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log($"{other.gameObject.name} take {damage} damages");
            Life life = other.gameObject.GetComponent<Life>();
            life.TakeDamage(damage);

            bombLife.TakeDamage(bombLife.GetHp());
        }
    }
}
