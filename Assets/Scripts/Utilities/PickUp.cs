using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private GameObject weapon;
    [SerializeField] private float reSpawn;
    private float pickUpAtTime;


    // GAME //-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-

    private void Update()
    {
        if (Time.time - pickUpAtTime > reSpawn)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            GetComponentInChildren<Collider2D>().enabled = true;
        }
    }


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
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            GetComponentInChildren<Collider2D>().enabled = false;
        }
    }
}