using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class titleEvents : MonoBehaviour {

    public AudioClip errSound;
    private AudioSource adosrc;

    // Use this for initialization
    void Awake()
    {
        adosrc = GetComponent<AudioSource>();
    }

    void beep()
    {
        //set the food step sound
        adosrc.PlayOneShot(errSound);
    }
}
