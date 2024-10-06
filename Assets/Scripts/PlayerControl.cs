using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [Header("Player Stats")]
    [SerializeField] float speed = 4f;
    [SerializeField] float climbSpeed = 5f;
    [SerializeField] float rollSpeed = 2f;

    [SerializeField] LayerMask playerLayer;

    private float horizontal_move;
    private float vertical_move;
    
    

    [SerializeField]private Vector3 spawnPos = new Vector3(-6f, -3.5f, 0f);

    Rigidbody2D rb;
    BoxCollider2D col;
    SpriteRenderer sprt;

    [Header("Animated Body")]
    [SerializeField] private Transform body;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
        sprt = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        horizontal_move = Input.GetAxisRaw("Horizontal");
        vertical_move = Input.GetAxisRaw("Vertical");
        
        if(horizontal_move < 0)
        {
            sprt.flipX = true;
            body.Rotate(Vector3.forward * rollSpeed);
        }
        else if (horizontal_move > 0)
        {
            sprt.flipX = false;
            body.Rotate(-Vector3.forward * rollSpeed);
        }
        else
        {

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Ladder")
        {
            rb.velocity = new Vector2(rb.velocity.x, vertical_move * climbSpeed);
        }
    }

    //bool CheckGrounded()
    //{
    //    //Vector3 fixedBounds = col.bounds.size / 2;
    //    //return Physics2D.BoxCast(col.bounds.center, fixedBounds, 0, -transform.up, 0.01f, playerLayer);
    //    return Physics2D.Raycast(col.bounds.center, -transform.up, 0.2f, playerLayer);
    //}


    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Terrain")
    //    {
    //        jumped = false;
    //    }
    //}

    //private bool JumpDebug()
    //{
    //    bool nowGrounded;
    //    if (jumped && CheckGrounded())
    //    {
    //        jumped = false;
    //        nowGrounded = true;
    //        jumpDebugTimer = 1.5f;
    //    }
    //    else if(jumped)
    //    {
    //        nowGrounded = false;
    //    }
    //    else
    //    {
    //        nowGrounded = true;
    //        jumpDebugTimer = 1.5f;
    //    }

    //    return nowGrounded;
    //}

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal_move * speed, rb.velocity.y);
        //if (jump && !jumped)
        //{
        //    rb.AddForce(new Vector2(0f,jumpVelocity), ForceMode2D.Impulse);
        //    jumped = true;

        //    //jumpDebugTimer = 1.5f;
        //    //jumpTimerStarted = true;
        //}
    }

    public void ReturnToRoom()
    {
        transform.position = spawnPos;
    }
}
