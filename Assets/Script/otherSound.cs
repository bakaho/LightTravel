using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class otherSound : MonoBehaviour {


	public AudioClip DieSound;
	public AudioClip WinClip;
	private AudioSource adosrc;

	// Use this for initialization
	void Awake () {
		adosrc = GetComponent<AudioSource> ();
	}

	//updat the sound effect for the character
	void DieHappens(){
		adosrc.PlayOneShot(DieSound);
	}

	void WinSound(){
		adosrc.PlayOneShot(WinClip);
	}


}
