using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sayHey : MonoBehaviour {

    public AudioClip heySound;
    private AudioSource adosrc;

    // Use this for initialization
    void Awake()
    {
        adosrc = GetComponent<AudioSource>();
    }

    void Hey()
    {
        //set the food step sound
        adosrc.PlayOneShot(heySound);
    }
}
