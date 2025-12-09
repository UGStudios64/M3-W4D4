using UnityEngine;
using UnityEngine.UIElements;

public class Life : MonoBehaviour
{
    [SerializeField] int maxhp;
    [SerializeField] private int hp;

    // For the animator
    private bool AsHit;
    private bool IsDeath;

    [SerializeField] private float destroyTime = 1f;

    // Sound
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip[] hit;
    private int randomHit;
    [SerializeField] private AudioClip death;


    // GAME //-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-
    private void Awake()
    {
        hp = maxhp;
        if (source == null) source = GetComponent<AudioSource>();
    }


    // FUNCTIONS //-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-
    public void TakeDamage(int damage)
    {
        hp -= damage;

        if (hp <= 0)
        {
            // SetUp the Death sequence
            GetComponent<Collider2D>().enabled = false;
            this.tag = "Untagged";
            source.PlayOneShot(death);
            IsDeath = true;

            Debug.Log($"{gameObject.name} is dead");
            Destroy(gameObject, destroyTime);
        }
        else
        {  
            AsHit = true;
            randomHit = Random.Range(0, hit.Length);
            source.PlayOneShot(hit[randomHit]);
            Debug.Log($"{gameObject.name} has {hp}/{maxhp}");
        }
    }

    public void TakeHeal(int amout)
    {
        hp += amout;

        if (hp > maxhp) hp = maxhp;
        Debug.Log($"{gameObject.name} ha {hp}/{maxhp}");
    }


    // GET-SET //--------------------------------------------------------
    public int GetHp()
    { return hp; }

    // For the animator
    public bool GetHit()
    { return AsHit; }
    public void SetHitFalse()
    { AsHit = false; }

    // For the animator
    public bool GetDeath()
    { return IsDeath; }
    public bool SetDeathFalse()
    { return IsDeath = false; }
}