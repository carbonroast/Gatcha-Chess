using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerConnectionSetup : NetworkBehaviour {

	[SerializeField]
	Behaviour[] componentsToDisable;

	public Camera cam;
	// Use this for initialization
	void Start () {
		if (!isLocalPlayer) {
			for (int i = 0; i < componentsToDisable.Length; i++) {
				componentsToDisable [i].enabled = false;
			}
			cam.enabled = false;
			return;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
