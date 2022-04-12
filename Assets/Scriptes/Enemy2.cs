using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public float speed;
    public float gravity;


    private Rigidbody2D rb;
    private SpriteRenderer sr;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        if (sr.isVisible)//見えたとき
        {
            rb.velocity = new Vector2(-speed, -gravity);
        }
        else
        {
            rb.Sleep();
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<GameOver>().gameover();
            FindObjectOfType<Score>().Save();
            Time.timeScale = 0.0f;
        }
    }
}