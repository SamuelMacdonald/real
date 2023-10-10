using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emeny : MonoBehaviour
{
    public GameObject player;
    public float speed;
    private float distance;
    SpriteRenderer sr;
    HelperScript helper; 
    // Start is called before the first frame update
    void Start()
    {
        //
        sr = GetComponent<SpriteRenderer>();
        helper = gameObject.AddComponent<HelperScript>();   
    }

    // Update is called once per frame  
    void Update()
    {
        if (Input.GetKey("y"))
        {
            helper.FlipObject(true); 
        }
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;

    transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
