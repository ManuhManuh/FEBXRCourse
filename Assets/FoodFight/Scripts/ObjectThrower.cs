using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectThrower : MonoBehaviour
{
    public string triggerName;
    public Rigidbody[] objects;
    private Rigidbody heldObject;
    public float throwImpulse;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // If the hand's trigger has been pressed
        if (Input.GetButtonDown(triggerName))
        {
            // Choose a random object to spawn
            Rigidbody randomObject = objects[Random.Range(0, objects.Length)];

            // Spawn the object (transform is that of the object the script is on; becomes child of same
            heldObject = Instantiate(randomObject, transform.position, transform.rotation, transform);

            // Attach the object to the hand (disable physics) - isKinematic is the screw Newton button
            heldObject.useGravity = false;
            heldObject.isKinematic = true;
        }


        if (Input.GetButtonUp(triggerName))
        {
            // Detach the object from the hand
            heldObject.transform.SetParent(null);
            heldObject.useGravity = true;
            heldObject.isKinematic = false;

            // Apply force to the object to throw it (note that gravity is down only)
            heldObject.AddForce(transform.forward * throwImpulse);

        }
    }
}
