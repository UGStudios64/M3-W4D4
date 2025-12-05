using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    [SerializeField] private string horizontal = "hSpeed";
    [SerializeField] private string vertical = "vSpeed";

    private Animator anim;
    private PlayerMove player;


    // GAME //-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-
    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        player = GetComponent<PlayerMove>();
    }

    private void Update()
    {
        anim.SetFloat(horizontal, player.GetDirection().x);
        anim.SetFloat(vertical, player.GetDirection().y);

        anim.SetBool("Move", player.GetMove());
    }
}
