using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    [SerializeField] int maxhp;
    [SerializeField] private int hp;


    // GAME //-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-
    private void Awake()
    {
        hp = maxhp;
    }

    // FUNCTIONS //-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-
    public void TakeDamage(int damage)
    {
        hp -= damage;

        if (hp <= 0)
        {
            Debug.Log($"{gameObject.name} is dead");
            Destroy(gameObject);
        }
        else { Debug.Log($"{gameObject.name} has {hp}/{maxhp}"); }
    }


    public void TakeHeal(int amout)
    {
        hp += amout;

        if (hp > maxhp) { hp = maxhp; }
        Debug.Log($"{gameObject.name} ha {hp}/{maxhp}");
    }
}
