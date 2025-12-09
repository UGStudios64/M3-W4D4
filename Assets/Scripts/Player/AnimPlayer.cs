using UnityEngine;

public class AnimPlayer : MonoBehaviour
{
    [SerializeField] private string horizontal = "hSpeed";
    [SerializeField] private string vertical = "vSpeed";

    private Animator anim;
    private MovePlayer player;
    private Life life;


    // GAME //-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-
    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        player = GetComponent<MovePlayer>();
        life = GetComponent<Life>();
    }

    private void Update()
    {
        // IDLE
        anim.SetBool("Move", player.GetMove());

        // WALK
        anim.SetFloat(horizontal, player.GetDirection().x);
        anim.SetFloat(vertical, player.GetDirection().y);

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
