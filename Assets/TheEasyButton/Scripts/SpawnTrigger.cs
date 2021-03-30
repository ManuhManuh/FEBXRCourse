using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrigger : Touchable
{
    public EasyButton game;
    public string buttonName;
    public GameObject easyButton;
    public GameObject spawnOrigin;

    private void Update()
    {
        if (Input.GetButtonDown(buttonName))
        { 
            game.OnSpawnRequested();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == easyButton)
        {
            game.OnSpawnRequested();
        }
        
    }
}
