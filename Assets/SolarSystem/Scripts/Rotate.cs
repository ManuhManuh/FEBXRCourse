using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float degreesPerSecond;

    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log("The start method was run");

    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the object at a certain speed around the y axis
        // multiplying by time.deltatime changes it from degrees per frame to degrees per second
        transform.Rotate(0f, degreesPerSecond * Time.deltaTime, 0f);
    }
}
