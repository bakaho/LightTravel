//Gao Ya
//54380279

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileSet : MonoBehaviour {
	public GameObject player;
	public Transform obj;
	public bool isIn = false;


	// Update is called once per frame
	void Update () {
		
		//if the player is inside this region
		if (player.transform.position.x < this.transform.position.x + 5 
			&& player.transform.position.x > this.transform.position.x - 5
			&& player.transform.position.z < this.transform.position.z + 5 
			&& player.transform.position.z > this.transform.position.z - 5) {
			isIn = true;
			//set the player's y accordingly
			Vector3 offset = new Vector3 (0, this.transform.position.y + 30f - player.transform.position.y, 0);
			player.transform.position += offset;
			characterX.moveHolder.position += offset;
		} else {
			isIn = false;
		}

	}




}
