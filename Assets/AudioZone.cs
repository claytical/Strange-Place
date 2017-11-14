using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioZone : MonoBehaviour {
	public AudioMixerSnapshot mix;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			mix.TransitionTo (1f);
			Debug.Log ("Switching Audio Snapshot");
		}
	}
}
