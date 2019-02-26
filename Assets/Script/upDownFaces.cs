//Gao Ya
//54380279

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upDownFaces : MonoBehaviour {
	//select the part

	//set color of the plane
	Renderer rend;
	public Material[] skin;

	void Start () {
		rend = GetComponent<Renderer> ();
		rend.enabled = true;
		rend.sharedMaterial = skin [0];
	}

	void OnMouseDrag(){
		//move the cube along with the mouse
		this.transform.parent.position += new Vector3 (0, 2f*Input.GetAxis ("Mouse Y"), 0);
	}

	//change skin
	void OnMouseEnter(){
		if (!GameManager.gamePaused && !characterX.winFinished) {
			rend.sharedMaterial = skin [1];
		}

	}
	void OnMouseExit(){
		if (!GameManager.gamePaused && !characterX.winFinished)
			rend.sharedMaterial = skin [0];
	}

}
