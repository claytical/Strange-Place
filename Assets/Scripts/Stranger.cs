using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stranger : MonoBehaviour {
	public GameObject thingHeThrows;
	public bool followsYou;
	private bool talkingToYou;
	public GameObject whatIFollow;
	public float maxRotationY;
	public float rotationSpeed;
	public float speedAtWhichIStalk;
	public float raycastDistance;
	public float timeUntilRaycastReset;
	private float raycastTimer;
	public bool showDebugRaycastLine;
	public GameObject dialoguePanel;
	private bool sawYou;

	// Use this for initialization
	void Start () {
		sawYou = false;
		raycastTimer = Time.time;
	}

	public void StopFollowing() {
		followsYou = false;
		talkingToYou = false;
		dialoguePanel.SetActive (false);
		whatIFollow.SetActive (true);

	}
	// Update is called once per frame
	void Update () {
//		Vector3 fwd = transform.TransformDirection(Vector3.forward);
	//the model is facing right, otherwise this would be forward
		if (!talkingToYou) {
			if (showDebugRaycastLine) {
				Debug.DrawRay (transform.position, transform.right * -raycastDistance, Color.green);
			}

			if (!sawYou) {
				transform.rotation = Quaternion.Euler (0f, maxRotationY * Mathf.Sin (Time.time * rotationSpeed), 0f);

			}

			if (followsYou) {
				if (Vector3.Distance (transform.position, whatIFollow.transform.position) >= 2) {
					transform.position = Vector3.MoveTowards (transform.position, whatIFollow.transform.position, Time.deltaTime * speedAtWhichIStalk);
					transform.LookAt (whatIFollow.transform);
				} else {
					//Start Conversation
					talkingToYou = true;
					Camera.main.enabled = false;
					GetComponentInChildren<Camera> ().enabled = true;
					dialoguePanel.SetActive (true);
					whatIFollow.SetActive (false);
				}

			}

			if (Time.time >= raycastTimer) {
				sawYou = false;
				//Debug.Log ("Stranger will find you again.");
			}

			RaycastHit hit;
			if (Physics.Raycast (transform.position, transform.right * -raycastDistance, out hit)) {
				if (sawYou == false) {
					sawYou = true;
					GameObject newObj = (GameObject)Instantiate (thingHeThrows);
					newObj.transform.parent = transform;
					newObj.transform.localPosition = Vector3.zero;
					newObj.GetComponent<Snowball> ().thingIFollow = hit.collider.gameObject;
					raycastTimer = timeUntilRaycastReset + Time.time;
				}


			}	
		} else {
			//Stranger is talking to you

		}
	}
}
