using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardMove : MonoBehaviour
{
    Rigidbody2D rb;
    public float distancePerSecond = 1.5f;
    int abilityCheck = 0;                   // Power up
    static public bool heartFlag = false;   // true if heart can spawn

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        heartFlag = false;
        // Amount to move in each dimension
        float dx = 0;
        float dy = 0;

        // Move up
        if (Input.GetKey (KeyCode.UpArrow)) {
            dy = distancePerSecond * Time.deltaTime;
        }
        // Move down
        if (Input.GetKey (KeyCode.DownArrow)) {
            dy = -distancePerSecond * Time.deltaTime;
        }
        // Move left
        if (Input.GetKey (KeyCode.LeftArrow)) {
            dx = -distancePerSecond * Time.deltaTime;
        }
        // Move right
        if (Input.GetKey (KeyCode.RightArrow)) {
            dx = distancePerSecond * Time.deltaTime;
        }
        // Move by that amount
        rb.position += new Vector2(dx, dy);

        // Power up only usable three times
        if (abilityCheck < 3)
        {
            // Press space to use the special ability
            if (Input.GetKeyDown("space"))
            {
                heartFlag = true;
                // Teleport to coin
                GameObject c = GameObject.FindWithTag("Coin");        // c = coin
                if (c == null) return;

                Rigidbody2D crb = c.GetComponent<Rigidbody2D>();      // crb = coin Rigidbody
                float x = crb.position.x;                             // coin x position
                float y = crb.position.y;                             // coin y position

                rb.position = new Vector2(x,y);                       // new player position
                abilityCheck++;
            }
        }
        
        
    }
}
