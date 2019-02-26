using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class txtAbove : MonoBehaviour {
    public Image instructionTxt;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 txtPos = Camera.main.WorldToScreenPoint(this.transform.position);
        instructionTxt.transform.position = txtPos;
		
	}
}
