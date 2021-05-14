using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardMovement : MonoBehaviour
{
    Rigidbody2D rb;                     // This object's Rigidbody
    SpriteRenderer spriteRenderer;      // This object's SpriteRenderer
    float distancePerSecond = 0.5f;     // Guard speed
    bool collectCoin = false;           // Determine if coin close enough

    public GameObject house;
    Rigidbody2D hrb;

    // Start is called before the first frame update
    void Start()
    {
        // Get Rigidbody and SpriteRenderer
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        hrb = house.GetComponent<Rigidbody2D>();    // hrb = house Rigidbody 
    }

    // Update is called once per frame
    void Update()
    {
        if (collectCoin)
        {
            GameObject c = GameObject.FindWithTag("Coin");        // c = coin
            if (c == null) return;

            Rigidbody2D crb = c.GetComponent<Rigidbody2D>();      // crb = coin Rigidbody

            // Move toward coin
            Vector2 delta = crb.position - rb.position;
            delta.Normalize();
            rb.position += delta * distancePerSecond * Time.deltaTime;
            
            // Face sprite in direction of coin
            spriteRenderer.flipX = (rb.position.x > crb.position.x);
        }
        else
        {
            // Move toward house
            Vector2 delta = hrb.position - rb.position;
            delta.Normalize();
            rb.position += delta * distancePerSecond * Time.deltaTime;

            // Face sprite in direction of house
            spriteRenderer.flipX = (rb.position.x > hrb.position.x);
        }
    }

    // Trigger movement
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if object collided with is coin
        GameObject c = collision.gameObject;
        if (c.CompareTag("Coin"))
        {
            // Start moving toward coin
            collectCoin = true;
        }
    }

    // Stop movement
    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject c = collision.gameObject;
        if (c.CompareTag("Coin"))
        {
            // Stop moving toward coin
            collectCoin = false;
        }
    }
}
