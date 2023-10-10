using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml;
using Unity.VisualScripting;
using UnityEngine;

public class JamesScript : MonoBehaviour
{
    Rigidbody2D rb;
    private CapsuleCollider2D coll;
    Animator anim;
    bool isGrounded;
    SpriteRenderer sr;
    Coin coin;

    [SerializeField] private LayerMask jumableground;
    // Start is called before the first frame update
    void Start()
    {
        print("start");
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<CapsuleCollider2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        coin = GetComponent<Coin>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("walk", false);
        anim.SetBool("jump", false);
        anim.speed = 1;
        int speed = 3;
        if (Input.GetKeyDown("space")) 
        {
            speed = 4;
        }
        if (Input.GetKeyDown("space") && IsGrounded())
        {
            rb.AddForce(new Vector3(0, 5, 0), ForceMode2D.Impulse);
        }
        if(Input.GetKey("w"))
        {
            speed = 6;
            anim.speed = 2;
        }
        if (IsGrounded() == false)
        {
            anim.SetBool("jump", true);
        }
        if (Input.GetKey("a"))
        {
            sr.flipX = true;
            transform.position = new Vector2(transform.position.x + (-speed * Time.deltaTime), transform.position.y);
            anim.SetBool("walk", true);
        }
        if (Input.GetKey("d") == true)
        {
            sr.flipX = false;
            transform.position = new Vector2(transform.position.x + (speed * Time.deltaTime), transform.position.y);
            anim.SetBool("walk", true);
        }
        if (Input.GetKeyDown("e"))
        {
            anim.SetTrigger("Attack lite");
        }
        if (Input.GetKeyDown("f"))
        {
            anim.SetTrigger("Attack heavy");
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumableground);
    }
}






