using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public float foodLifeSpan;
    private float foodTimer;
    private float timeSinceThrown;

    private void Awake()
    {
        foodTimer = Time.time;
    }
    
    void Update()
    {
        
        timeSinceThrown = Time.time - foodTimer;
        // if timer has run out
        if (timeSinceThrown > foodLifeSpan)
        {
            // destroy the food
            Destroy(gameObject);
        }
    }
}
