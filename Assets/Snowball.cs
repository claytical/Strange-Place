using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowball : MonoBehaviour {
	public GameObject thingIFollow;
	public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (thingIFollow != null) {
			transform.position = Vector3.MoveTowards (transform.position, thingIFollow.transform.position, Time.deltaTime * speed);
		} else {
			transform.Translate (transform.forward * 1.5f);
//			transform.position = Vector3.MoveTowards (transform.position, transform.position + transform.forward, Time.deltaTime);
		}
	}
}
