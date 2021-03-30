using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : Grabbable
{
    public Light frontLight;

    public override void Start()
    {
       base.Start();
        frontLight.enabled = false;
    }

    public override void OnTriggerStart()
    {
        frontLight.enabled = true;
    }

    public override void OnTriggerEnd()
    {
        frontLight.enabled = false;
    }
}
