using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Lever : MonoBehaviour
{
    public float onAngleThreshold;
    public float offAngleThreshold;

    private HingeJoint hinge;
    private bool pushedForward;
    private bool pulledBackward;

    public UnityEvent turnedOn;
    public UnityEvent turnedOff;

    // Start is called before the first frame update
    void Start()
    {
        hinge = GetComponent<HingeJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        // If the lever is fully pushed forward and wasn't already on
        if(hinge.angle > onAngleThreshold && !pushedForward)
        {
            pushedForward = true;
            turnedOn.Invoke();
        }
        // If the lever was pushed forward and isn't any more
        if(hinge.angle < onAngleThreshold)
        {
            pushedForward = false;
        }
        // If the lever is fully pulled backward and wasn't already off
        if (hinge.angle < offAngleThreshold && !pulledBackward)
        {

            pulledBackward = true;
            turnedOff.Invoke();
        }

        //if the lever was fully pulled backward and isn't any more
        if (hinge.angle > onAngleThreshold)
        {
            pulledBackward = false;
        }
    }
}
