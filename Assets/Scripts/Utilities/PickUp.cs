using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private GameObject weapon;
    [SerializeField] private float reSpawn;

    // For make the object respawn
    private float pickUpAtTime;
    public bool Respawn = true;


    // GAME //-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-
    private void Update()
    {
        // Enable the Object
        if (Time.time - pickUpAtTime > reSpawn && Respawn)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            GetComponentInChildren<Collider2D>().enabled = true;
        }
    }


    // COLLISION //--------------------------------------------------------
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log($"{other.name} Equip {gameObject.name}");

            // Set the prefab as a children of Player
            GameObject weap = Instantiate(weapon);
            weap.transform.parent = other.transform;
            weap.transform.position = other.transform.position;

            pickUpAtTime = Time.time;

            // Disable the Object
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            GetComponentInChildren<Collider2D>().enabled = false;
        }
    }
}