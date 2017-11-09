using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {
	public GameObject bullet;
	public GameObject target;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1")) {

			RaycastHit hit;
			if (Physics.Raycast (transform.position, transform.right * -1f, out hit)) {
				GameObject newObj = (GameObject)Instantiate (bullet);
				target = hit.collider.gameObject;
				newObj.GetComponent<Snowball> ().thingIFollow = target;			
				newObj.transform.position = transform.position;

			} else {
				GameObject newObj = (GameObject)Instantiate (bullet);
				newObj.transform.position = transform.position;
				newObj.transform.rotation = transform.rotation;
			}


		}
	}
}
