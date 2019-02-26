using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteWave : MonoBehaviour {
    public Animator animW;

    // Use this for initialization
    void Awake()
    {
        animW = this.GetComponent<Animator>();
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void noWave()
    {
        animW.SetBool("showWave", false);
    }
}
