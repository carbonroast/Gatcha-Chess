﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerConnectionSetup : NetworkBehaviour {

	[SerializeField]
	Behaviour[] componentsToDisable;

	public Camera cam;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
