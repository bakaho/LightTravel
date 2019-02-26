//Gao Ya
//54380279

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upDownGroup1 : MonoBehaviour {
	//select the part
	public Transform follow;
	public float n = 1f;
	public float limitHeight = -30f;



	void OnMouseDrag(){
		//add limitation
		if (this.transform.parent.position.y >= limitHeight) {
			follow.position += new Vector3 (0, n * 2f * Input.GetAxis ("Mouse Y"), 0);
		}
	}
		

}
