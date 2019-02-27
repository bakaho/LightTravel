//Gao Ya
//54380279

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footstep : MonoBehaviour {

	public AudioClip stepSound;
	private AudioSource adosrc;

	// Use this for initialization
	void Awake () {
		adosrc = GetComponent<AudioSource> ();
	}
	
	void Step(){
		//set the food step sound
		adosrc.PlayOneShot(stepSound);
	}

}
