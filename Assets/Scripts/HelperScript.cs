using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class HelperScript : MonoBehaviour
{
    public LayerMask groundLayerMask;

    public void FlipObject(bool flip)
    {
        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();

        if (flip == true)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
    }
    void Start()
    {
        groundLayerMask = LayerMask.GetMask("Ground");
    }
    public void DoRayCollisionCheck()
    {
        float rayLength = 0.5f; 


        RaycastHit2D hit;

        hit = Physics2D.Raycast(transform.position, -Vector2.up, rayLength, groundLayerMask);

        Color hitColor = Color.white;


        if (hit.collider != null)
        {
            print("Player has collided with Ground layer");
            hitColor = Color.green;
        }
        Debug.DrawRay(transform.position, -Vector2.up * rayLength, hitColor);

    }



}
