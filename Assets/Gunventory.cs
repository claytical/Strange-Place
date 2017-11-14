using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gunventory : MonoBehaviour {
	public GameObject[] bullets;
	public Button[] buttons;
	public Gun gun;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.S)) {
			buttons [0].interactable = true;
			buttons [1].interactable = false;
			buttons [2].interactable = false;
			gun.bullet = bullets [0];

		}

		if (Input.GetKey (KeyCode.F)) {
			buttons [0].interactable = false;
			buttons [1].interactable = true;
			buttons [2].interactable = false;
			gun.bullet = bullets [1];

		}
		if (Input.GetKey (KeyCode.W)) {
			buttons [0].interactable = false;
			buttons [1].interactable = false;
			buttons [2].interactable = true;
			gun.bullet = bullets [2];
		}

	}
}
