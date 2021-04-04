using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pushable : MonoBehaviour
{
    public GameObject pusherSquare;

    private FixedJoint joint;

    public void OnPushed(Grabber grabber)
    {

        // Make it so that the hand can push the button down
        //Instantiate(pusherSquare, grabber.transform.position, grabber.transform.rotation);
        //joint = pusherSquare.AddComponent<FixedJoint>();
        //joint.connectedBody = grabber.GetComponent<Rigidbody>();
    }

    public void OnPushReleased(Grabber grabber)
    {

        // Return hand to normal behaviour
        // Destroy(pusherSquare);

    }
}
