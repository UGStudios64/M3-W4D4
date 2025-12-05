using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField][Range(0f, 10f)] float speed;
    [SerializeField] private Rigidbody2D rb;

    public bool IsMoving;
    private float horizontal;
    private float vertical;
    private Vector2 direction;


    // GAME //-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-
    void Awake()
    {
        if (rb == null) rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        IsMoving = direction != Vector2.zero;
    }

    private void FixedUpdate()
    {
        direction = new Vector2(horizontal, vertical);

        // Vector normalized
        float mag = direction.magnitude;
        if (mag > 1f) direction /= mag;

        rb.MovePosition(rb.position + direction * (speed * Time.fixedDeltaTime));
    }


    // FUNCTIONS //-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-
    public Vector2 GetDirection()
    { return direction; }

    public bool GetMove()
    { return IsMoving; }
}
