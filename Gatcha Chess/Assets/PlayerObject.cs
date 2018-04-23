using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
        // Player object is invisible and not part of the world
        // give me something physical to move around
        Debug.Log("PlayerObject::Start -- Spawning my own personal player unit");
        Instantiate(PlayerUnitPrefab);
	}

    public GameObject PlayerUnitPrefab;
	
	// Update is called once per frame
	void Update () {
		
	}
}
