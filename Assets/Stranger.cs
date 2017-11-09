using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stranger : MonoBehaviour {
	public GameObject thingHeThrows;
	private bool sawYou;
	public bool followsYou;
	public GameObject whatIFollow;
	public float speedAtWhichIStalk;
	// Use this for initialization
	void Start () {
		sawYou = false;
	}
	
	// Update is called once per frame
	void Update () {
//		Vector3 fwd = transform.TransformDirection(Vector3.forward);
	//the model is facing right, otherwise this would be forward
		RaycastHit hit;
		if (Physics.Raycast(transform.position, transform.right * -1f, out hit)) {
			if (sawYou == false) {
				Debug.Log ("The stranger sees you...");
				sawYou = true;
				GameObject newObj = (GameObject)Instantiate (thingHeThrows);
				newObj.GetComponent<Snowball> ().thingIFollow = hit.collider.gameObject;
			}


		}	

		if (followsYou) {
			transform.position = Vector3.MoveTowards (transform.position, whatIFollow.transform.position, Time.deltaTime * speedAtWhichIStalk);
			transform.LookAt (whatIFollow.transform);
		}
	}
}
