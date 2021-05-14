using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDestroy : MonoBehaviour
{
    // Tag of object to teleport on collision
    public string[] targetTags = {"Player", "Enemy"};
    Rigidbody2D rb;
    
    // Check if object that collided with this one is a target
    private bool IsTargetTag(GameObject other)
    {
        for (int i=0; i < targetTags.Length; i++)
        {
            if (other.CompareTag(targetTags[i]))
                return true;
        }
        return false;
    }

    // Called when this object collides with another
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Get reference to other game object from parameter
        GameObject other = collision.gameObject;

        // If it has the tag we are looking for, destroy it
        if (IsTargetTag(other))
        {
            GameObject.Destroy(gameObject);
        }
    }
}