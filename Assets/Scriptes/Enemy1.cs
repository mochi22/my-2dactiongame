using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy1 : MonoBehaviour
{
    public float speed;
    public float gravity;
    public float jp = 100;
    public float jpTime;
    public float RandomTime;
    public float JpMax;

    public bool isGround;

    private Rigidbody2D rb;
    private SpriteRenderer sr;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        Time.timeScale = 1;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Ground")
        {
            isGround = true;
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
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Ground")
        {
            isGround = false;
        }
    }
    void FixedUpdate()
    {
        if (sr.isVisible)//見えたとき
        {
            jpTime = Random.Range(2.0f, 10.0f);
            RandomTime += Time.deltaTime;
            if (jpTime <= RandomTime)
            {
                RandomTime = 0.0f;
                if (isGround)
                {
                   rb.velocity = new Vector2(-speed / 2, jp);                    
                }
            }

            if (this.transform.position.y > JpMax)
            {
                rb.velocity = new Vector2(-speed, -gravity);
            }
            if (rb.velocity.y <= 0)
            {
                rb.velocity = new Vector2(-speed, -gravity);
            }       
        }
        else
        {
            rb.Sleep();
        }
    }
}