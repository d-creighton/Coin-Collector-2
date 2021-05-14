using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateHouses : MonoBehaviour
{
    // House to generate
    public GameObject HousePrefab;
    // Guard to generate
    public GameObject GuardPrefab;

    

    // Start is called before the first frame update
    void Start()
    {
        // Spawn houses
        GameObject go1 = (GameObject)Instantiate(HousePrefab, new Vector2(-7,0), Quaternion.identity);
        GameObject go2 = (GameObject)Instantiate(HousePrefab, new Vector2(7,0), Quaternion.identity);
        // Spawn guards
        Instantiate(GuardPrefab, new Vector2(-7, 0), Quaternion.identity);
        Instantiate(GuardPrefab, new Vector2(7, 0), Quaternion.identity);
    }
}
