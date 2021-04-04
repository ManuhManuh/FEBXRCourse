using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SliderObject : MonoBehaviour
{
    public float minX;
    public float maxX;
    public UnityEvent onValueChanged;
    public float value;

    private float prevValue = 0f;

    // Update is called once per frame
    void Update()
    {
        // Calculate how far along the slider is as a percentage (0 - 1)

        value = (transform.localPosition.x - minX / (maxX - minX));
        value = Mathf.Clamp(value, 0f, 1f);     // forces the first number to be between the second and third numbers

        if(value != prevValue)
        {
            onValueChanged.Invoke();
            prevValue = value;
        }
    }
}
