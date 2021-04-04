using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyButton : MonoBehaviour
{
    public GameObject spawnOrigin;
    public Rigidbody[] officeSupplies;

    private void SpawnOfficeSupplies()
    {
        // Spawn random office supply item
        Rigidbody randomObject = officeSupplies[Random.Range(0, officeSupplies.Length)];

            Instantiate(randomObject, spawnOrigin.transform.position, spawnOrigin.transform.rotation);
    }

    public void OnCyborgHit()
    {
        // Spawn a new office supply item (spawnToHand is false - cyborg hit spawns to table only)

        // SpawnOfficeSupplies();   // overload of supplies - play sound effect instead

    }

    public void OnSpawnRequested()
    {
        // Spawn a new office supply item
        SpawnOfficeSupplies();
    }

    private void OnCollisionEnter(Collision collision)
    {
        SpawnOfficeSupplies();
    }
}
