using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float speed;
    public float range;
    public FoodFight game;

    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        
        // Slide the target back and forth (right and left are x axis)
        transform.position = initialPosition + transform.right * Mathf.Sin(Time.time * speed * range);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Let the game know that the target was hit
        game.OnTargetHit();

        // Destroy the target
        Destroy(gameObject);
    }
}
