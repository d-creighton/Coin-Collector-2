using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSpawn : MonoBehaviour
{
    Rigidbody2D rb;                             // this object's Rigidbody
    public GameObject HeartPrefab;              // prefab to use
    GameObject heart = null;                    // reference to current heart (none initially)
    //public float secondsToRemainVisible = 5.0f; // Time to remain visible
    //public float secondsToLast = 0.0f;          // Time to last

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Add time since last call to Update
        //secondsToLast += Time.deltaTime;

        if (KeyboardMove.heartFlag && heart == null)        // only spawn if not already there
        {
            // Start timer
            StartCoroutine(Countdown());

            // Get location next to player
            Vector2 where = rb.position + new Vector2(0.5f, -0.5f);

            // Spawn heart next to player
            heart = Instantiate(HeartPrefab, where, Quaternion.identity);

            // Parent it to player
            heart.transform.SetParent(this.transform);
        }

        /*if (secondsToLast >= secondsToRemainVisible)
        {
            // Destory heart after desired time
            Destroy(heart);
            heart = null;

            secondsToLast = 0;
        }*/
    }

    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(5);

        // Destory heart after desired time
        Destroy(heart);
        heart = null;
    }
}
