using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float speed;

    // The distance when the Enemy start to catch the Player
    [SerializeField] protected float maxDistance;

    protected MovePlayer player;
    protected float playerDistance;
    protected Vector2 direction;
    protected bool IsMoving;

    // Damage and Wait Time, the Enemy walk back Before attacking again
    [SerializeField] protected int damage;
    protected float lastAttack = -1f;
    protected float wait = 0.5f;
    protected bool IsAttack;


    // GAME //-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-
    protected void Awake()
    {
        player = FindAnyObjectByType<MovePlayer>();
    }

    protected void Update()
    {
        IsMoving = direction != Vector2.zero;
    }

    protected void FixedUpdate()
    {
        if (player == null) IsAttack = false;

        if (Time.time - lastAttack > wait)
        {
            IsAttack = false;
            EnemyMovement();
        }
        else EnemyBack();
    }


    // COLLISION //--------------------------------------------------------
    protected virtual void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log($"{other.gameObject.name} take {damage} damages");
            Life life = other.gameObject.GetComponent<Life>();
            life.TakeDamage(damage);

            IsAttack = true;
            lastAttack = Time.time;
        }
    }


    // FUNCTIONS //-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-
    public void EnemyMovement()
    {
        if (player != null && player.CompareTag("Player") && CompareTag("Enemy") && !IsAttack)
        {
            playerDistance = Vector2.Distance(player.transform.position, transform.position);
            if (playerDistance < maxDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
                direction = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
            }
        }
    }

    public void EnemyBack()
    {
        if (IsAttack)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, -speed * Time.deltaTime);
            direction = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
        }
    }


    // GET //--------------------------------------------------------
    public Vector2 GetDirection()
    { return direction; }

    public bool GetMove()
    { return IsMoving; }
}