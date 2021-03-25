using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour
{
    public string gripInputName;
    // public float gripThreshold;
    public string triggerInputName;
    // public float triggerThreshold;

    private Grabbable touchedObject;
    private Grabbable grabbedObject;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // If the grip trigger is pressed
        if (Input.GetButtonDown(gripInputName))
        {
           // Update the animator to play the grip animation
           GetComponent<Animator>().SetBool("Gripped", true);

            // If we are touching an object, grab it
            if(touchedObject != null)
            {
                // Let the touched object know that it has been grabbed
                touchedObject.OnGrab(this);

                // Store the new grabbed object
                grabbedObject = touchedObject;
            }
            
        }
        if(Input.GetButtonUp(gripInputName))
        {
            // Update the animator to stop the grip animation
            GetComponent<Animator>().SetBool("Gripped", false);

            // If we have something grabbed, drop it
            if (grabbedObject != null)
            {

                // Let the touched object know it has been dropped
                grabbedObject.OnDrop();

                // Forget the grabbed object
                grabbedObject = null;
            }
                
        }

        if (Input.GetButtonDown(triggerInputName))
        {
            // If we are grabbing an object, call the trigger function
            if (grabbedObject != null)
            {
                // Let the grabbed object know that it has been triggered
                grabbedObject.OnTriggerStart();
            }
        }
        if(Input.GetButtonUp(triggerInputName))
        {
            // If we have something grabbed, call the stop trigger function
            if (grabbedObject != null)
            {
                // Let the touched object know it has stopped being triggered
                grabbedObject.OnTriggerEnd();
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        Grabbable grabbable = other.GetComponent<Grabbable>();
        
        // Check if the object we touched is grabbable (has the grabbable script on it)
        if(grabbable != null)
        {
            // Let the object know it was touched
            grabbable.OnTouched();

            // Store the currently touched object
            touchedObject = grabbable;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        Grabbable grabbable = other.GetComponent<Grabbable>();

        // Check if the object we stopped touching is grabbable (has the grabbable script on it)
        if (grabbable != null)
        {
            // Let the object know it is no longer being touched
            grabbable.OnUntouched();

            // Reset the touched object
            touchedObject = null;

        }
    }

 
}
