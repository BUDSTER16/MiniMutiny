using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [Header("Player Stats")]
    [SerializeField] float speed = 3f;
    [SerializeField] float jumpVelocity = 7f;
    [SerializeField] LayerMask playerLayer;

    private float horizontal_move;
    private bool jump;
    private bool jumped = false;

    private Vector3 spawnPos = new Vector3(-6f, -3.5f, 0f);

    Rigidbody2D rb;
    BoxCollider2D col;

    //private float jumpDebugTimer = 1.5f;
    //private bool jumpTimerStarted = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        horizontal_move = Input.GetAxisRaw("Horizontal");
        jump = Input.GetButton("Jump") && CheckGrounded();

        //if(jumpTimerStarted && jumpDebugTimer > 0) { jumpDebugTimer -= Time.deltaTime; }
        //else if (jumpDebugTimer <= 0) 
        //{ 
        //    jumpTimerStarted = false; 
        //    if(JumpDebug())
        //    {

        //    }
        //}
    }

    bool CheckGrounded()
    {
        //Vector3 fixedBounds = col.bounds.size / 2;
        //return Physics2D.BoxCast(col.bounds.center, fixedBounds, 0, -transform.up, 0.01f, playerLayer);
        return Physics2D.Raycast(col.bounds.center, -transform.up, 0.2f, playerLayer);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Terrain")
        {
            jumped = false;
        }
    }

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
        if (jump && !jumped)
        {
            rb.AddForce(new Vector2(0f,jumpVelocity), ForceMode2D.Impulse);
            jumped = true;

            //jumpDebugTimer = 1.5f;
            //jumpTimerStarted = true;
        }
    }

    public void ReturnToRoom()
    {
        transform.position = spawnPos;
    }
}
