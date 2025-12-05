using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    [SerializeField] private string horizontal = "hSpeed";
    [SerializeField] private string vertical = "vSpeed";
    [Space(10)]
    [SerializeField] private bool IsMoving;

    private Animator anim;
    private PlayerMove player;
    private Vector2 immovable = new Vector2(0,0);

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

        if (player.GetDirection() != immovable) IsMoving = true;
        else IsMoving = false;
    }
}
