using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonControl : MonoBehaviour {
    public Button showShape;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void hideThis(){
        showShape.gameObject.SetActive(false);
        myLight.shapeChange = true;
        myLight.lightShape = 2;
        CameraTilt.canMove = true;
        myLight.inControl = true;
        
    }
}
