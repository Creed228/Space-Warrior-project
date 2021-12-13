using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [Header("Movement")]

    public float speed;
    public float jumpForce;
    private float moveInput;

    private Rigidbody2D rb;
    private bool facingRight = true;
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        if (facingRight == false && moveInput < 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput > 0)
        {
            Flip();
        }
    }

    private void Update()
    {
        if (isGrounded == true && Input.GetButtonDown("Jump"))
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    void Flip()
    {
        facingRight = !facingRight; // asset is facing the wrong direction
        transform.Rotate(0f, 180f, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Finish")
        {
            GameController game = FindObjectOfType<GameController>();
            game.WinGame();
        }
        else if(collision.gameObject.tag == "Tutorial")
        {
            Tutorial t = FindObjectOfType<Tutorial>();
            t.Next();
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}