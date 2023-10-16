using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class JamesScript : MonoBehaviour
{
    Rigidbody2D rb;
    private CapsuleCollider2D coll;
    Animator anim;
    bool isGrounded;
    SpriteRenderer sr;
    Coin coin;
    HelperScript helper;
    [SerializeField] private LayerMask jumableground;
    bool thereGround = false;
    // Start is called before the first frame update
    void Start()
    {
        print("start");
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<CapsuleCollider2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        coin = GetComponent<Coin>();
        helper = gameObject.AddComponent<HelperScript>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("walk", false);
        anim.SetBool("jump", false);
        anim.speed = 1;
        int speed = 3;
        thereGround = helper.DoRayCollisionCheck();
        if (Input.GetKeyDown("space") )
        {
            rb.AddForce(new Vector3(0, 5, 0), ForceMode2D.Impulse);
            helper.DoRayCollisionCheck();
        }
        if(Input.GetKey("w") && IsGrounded())
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






