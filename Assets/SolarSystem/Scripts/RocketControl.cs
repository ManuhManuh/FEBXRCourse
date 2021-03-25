using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketControl : MonoBehaviour
{
    public float engineForce;
    public float turningForce;
    public float maxFuel = 100f;
    public float currentFuel;
    public float fuelUsedPerSecond;
    public FuelGauge fuelGauge;
    public GameObject engineLight;

    private Rigidbody rigidBody;
    private bool engineOn;
    
    // Start is called before the first frame update
    void Start()
    {
        // If on the same object, use GetComponent instead of using the inspector
        // caching the rigidbody
        rigidBody = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        currentFuel = maxFuel;
        fuelGauge.SetMaxFuel(maxFuel);
    }

    // Update is called once per frame
    void Update()
    {
        // Get mouse input (how much mouse has moved on x and y axis)
        float yaw = Input.GetAxis("Mouse X");   // y-axis
        float pitch = -Input.GetAxis("Mouse Y"); // x-axis

        // Rotate the rocket using the moust control; relative torque adds torque around object's own axes
        rigidBody.AddRelativeTorque(
                pitch * turningForce * Time.deltaTime,  //Pitch
                yaw * turningForce * Time.deltaTime,    //Yaw
                0f);                                    //Roll

        // turn on the rocket engine when W is pressed
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (currentFuel >= 5)
            {
                engineOn = true;
                engineLight.SetActive(true);
             
            }
            
        }

        // turn off the rocket engine when W is released
        if (Input.GetKeyUp(KeyCode.W))
        {
            engineOn = false;
            engineLight.SetActive(false);

        }


        if (engineOn)
        {
            // Apply an engine force
            rigidBody.AddForce(transform.forward * engineForce * Time.deltaTime);  // forward on the Z axis

            // Decrease the fuel by 1 unit per second
            UseFuel(fuelUsedPerSecond * Time.deltaTime);
        }
        // transform.Rotate(0f, degreesPerSecond * Time.deltaTime, 0f);

        // Interpolation string - nicer than concatenating ;)
        // Debug.Log ($"Mouse X: {yaw} Mouse Y: {pitch}");
    }

    public void UseFuel(float fuel)
    {
        currentFuel -= fuel;
        fuelGauge.SetFuel(currentFuel);
    }
}
