using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{

    public float speed = 7f;
    public Rigidbody2D rb;
    public AmmoController coin;
    GameObject enemy;

    void Start()
    {
        rb.velocity = transform.right * speed;
        enemy = GameObject.FindWithTag("Enemy");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(enemy.gameObject.GetComponent<Enemy>() != null) {
            if(other.tag == "Enemy" && enemy.gameObject.GetComponent<Enemy>().isDead) {
                Destroy(gameObject);
            }
        }
        else if (other.tag == "Wall" || other.tag == "Tile") Destroy(gameObject);
    }
}
