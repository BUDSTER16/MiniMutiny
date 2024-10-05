using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [Header("Player Stats")]
    [SerializeField] float speed = 2f;
    [SerializeField] float jumpVelocity = 5f;
    [SerializeField] LayerMask playerLayer;

    private float horizontal_move;
    private bool jump;
    private bool jumped = false;

    Rigidbody2D rb;
    BoxCollider2D col;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        horizontal_move = Input.GetAxisRaw("Horizontal");
        jump = Input.GetButton("Jump") && CheckGrounded();
    }

    bool CheckGrounded() => Physics2D.BoxCast(col.bounds.center, col.bounds.size, 0, -transform.up, 0.02f, playerLayer);

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Terrain")
        {
            jumped = false;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal_move * speed, rb.velocity.y);
        if (jump && !jumped)
        {
            rb.AddForce(new Vector2(0f,jumpVelocity), ForceMode2D.Impulse);
            jumped = true;
        }
    }
}
