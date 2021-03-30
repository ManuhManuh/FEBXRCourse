using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public float spawnInterval;
    public GameObject objectPrefab;

    private float spawnCountdown;
    
    // Start is called before the first frame update
    void Start()
    {
        spawnCountdown = spawnInterval;
    }

    // Update is called once per frame
    void Update()
    {
        spawnCountdown -= Time.deltaTime;
        if (spawnCountdown <= 0f)
        {
            SpawnObject();
            spawnCountdown = spawnInterval;
        }
    }

    private void SpawnObject()
    {
        Instantiate(objectPrefab, transform.position, Quaternion.identity);
    }
}
