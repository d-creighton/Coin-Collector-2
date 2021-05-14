using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCoinsTimed : MonoBehaviour
{
    public GameObject CoinPrefab;               // Coin to generate
    public float secondsBetweenCoins = 5.0f;    // Time between spawns
    public float secondsSinceLast = 0.0f;       // Time since last spawn
    public float rangeX = 8f;                   // X position range
    public float rangeY = 4f;                   // Y position range
    
    void Update()
    {
        // Add time since last call to Update
        secondsSinceLast += Time.deltaTime;
        
        // Generate random x and y coordinates within ranges
        float x = Random.Range(-rangeX, rangeX);
        float y = Random.Range(-rangeY, rangeY);

        // If total time more than time between spawns
        if (secondsSinceLast >= secondsBetweenCoins)
        {
            // Spawn a new coin
            GameObject coin = Instantiate(CoinPrefab, new Vector2(x, y), Quaternion.identity);

            // Reset timer
            secondsSinceLast = 0;
        }
        
    }
}
