using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class limitHeight : MonoBehaviour {
	public float limit = -30f;
	
	// set limitation for the translation
	void Update () {
		if (this.transform.position.y <= limit) {
			this.transform.position = new Vector3 (this.transform.position.x, limit, this.transform.position.z);

		}			
	}
}
