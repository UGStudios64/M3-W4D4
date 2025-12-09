using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip opening;

    [SerializeField] private GameObject juebox;
    private Animator anim;


    // GAME //-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-
    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        
        if (source == null) source = GetComponent<AudioSource>();
    }


    // COLLISION //--------------------------------------------------------
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            MovePlayer player = other.gameObject.GetComponent<MovePlayer>();

            if (player.GetKey())
            {
                player.SetKey(false);
                Destroy(juebox);
                anim.SetBool("Open", true);
                source.PlayOneShot(opening);
            }
        }
    }
}