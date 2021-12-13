using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameController gameController;

    GameObject player;
    GameObject bullet;
    GameObject enemy;
    const float speedMove = 1.0f;
    private SpriteRenderer sprite;
    private Rigidbody2D rb;
    private bool facingRight = true;
    private Animator anim;
    public bool isDead;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && !isDead)
            gameController.LoseGame();
    }

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        bullet = GameObject.FindGameObjectWithTag("Bullet");
        sprite = GetComponentInChildren<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    void Update()
    {
        float direction = player.transform.position.x - transform.position.x;
        Physics.IgnoreLayerCollision(9, 9, false);
        if (isDead)
        {
            if (player != null) Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            if(bullet != null) Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
        if (Mathf.Abs(direction) < 5 && !isDead)
        {
            Vector3 pos = transform.position;
            rb.velocity = new Vector2(direction * speedMove, rb.velocity.y);
            if (facingRight == false && direction < 0)
            {
                Flip();
            }
            else if (facingRight == true && direction > 0)
            {
                Flip();
            }
            anim.SetBool("isRunning", true);
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {
            anim.SetBool("isDead", true);
            isDead = true;
        }
    }
}
