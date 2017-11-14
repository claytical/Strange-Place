using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowball : MonoBehaviour {
	public GameObject thingIFollow;
	public float speed;
	public Vector3 direction;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (thingIFollow != null) {
//			transform.position = Vector3.MoveTowards (transform.position, thingIFollow.transform.position, Time.deltaTime * speed);
			transform.position = Vector3.Lerp (transform.position, thingIFollow.transform.position, Time.deltaTime * speed);
			//Debug.Log("Distance to Target: " + Vector3.Distance (transform.position, thingIFollow.transform.position));
			if (Vector3.Distance (transform.position, thingIFollow.transform.position) <= 1.5) {
			//	Debug.Log ("Met up with object");
				Destroy (gameObject);
			}

		} else {
			transform.position = transform.position + direction;
			//transform.Translate (transform.forward * 1.5f);
		}
	}

}
