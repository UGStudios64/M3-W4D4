using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] int damage;
    [SerializeField] float speed;
    [Space(10)]
    [SerializeField] float despawn;

    private Vector2 direction;


    // GAME //-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-
    void Awake()
    {
        if (rb == null) rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    { 
        Destroy(gameObject, despawn);
    }

    private void FixedUpdate()
    { 
        rb.velocity = direction * speed;
    }


    // COLLISION //--------------------------------------------------------
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log($"{other.gameObject.name} take {damage} damages");
            Life life = other.gameObject.GetComponent<Life>();
            life.TakeDamage(damage);

            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Wall")) Destroy(gameObject);
    }


    // FUNCTIONS //-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-
    public void SetUp(Vector2 direction)
    { this.direction = direction; }
}