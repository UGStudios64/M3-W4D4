using UnityEngine;

public class AnimEnemy : MonoBehaviour
{
    [SerializeField] private string horizontal = "hSpeed";
    [SerializeField] private string vertical = "vSpeed";

    private Animator anim;
    private Enemy enemy;
    private Life life;


    // GAME //-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-
    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        enemy = GetComponent<Enemy>();
        life = GetComponent<Life>();
    }

    private void Update()
    {
        // IDLE
        anim.SetBool("Move", enemy.GetMove());

        // WALK
        anim.SetFloat(horizontal, enemy.GetDirection().x);
        anim.SetFloat(vertical, enemy.GetDirection().y);

        // HIT
        if (life.GetHit())
        {
            anim.SetTrigger("Hit");
            life.SetHitFalse();
        }

        // DEATH
        if (life.GetDeath())
        {
            anim.SetTrigger("Death");
            life.SetDeathFalse();
        }
    }
}
