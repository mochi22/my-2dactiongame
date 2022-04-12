using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;//speedの値はunity上で変えられる
    public float jp = 500;//ジャンプ力

    private Rigidbody2D rb;
    private Animator anime;

    public bool isGround;//接地


    // Start is called before the first frame update
    void Start()
    {
        anime = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
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
        if (other.tag == "Ground")
        {
            isGround = true;
        }
        if (other.tag == "Enemy")
        {
            Destroy(other.gameObject);
            FindObjectOfType<Score>().AddPoint(10);
            rb.AddForce(Vector2.up * jp * 3 / 4);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Ground")
        {
            isGround = false;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (isGround)
            {
                anime.SetBool("Dash", false);
                anime.SetTrigger("Jump");

                rb.AddForce(Vector2.up * jp);

                anime.SetBool("Wait", true);

            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float x = Input.GetAxisRaw("Horizontal");//左右の矢印の入力に対して0から徐々に変化(→が+、←が-)しｘが+1または-1まで変化
        if (x != 0)
        {
            rb.velocity = new Vector2(x * speed, rb.velocity.y);
            Vector2 temp = transform.localScale;//49から52で反転を表現
            temp.x = x;
            transform.localScale = temp;
            anime.SetBool("Dash", true);
        }

        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            anime.SetBool("Dash", false);
        }
    }
}