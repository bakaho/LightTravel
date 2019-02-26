//Gao Ya
//54380279

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour {

	public GameObject htp;
	public GameObject menu;

	static public bool[] levelLocked = {true};
	public Text btnL2;



	//if level 2 is unlocked, set the text of the button
	void Start(){
		if (levelLocked [0] == false) {
			btnL2.text = "Chapter - Truth";
		}
	}

	//go to level 1
	public void startmenu(){
		SceneManager.LoadScene("level1v1");
	}

	//if level 2 is unlocked, go to level 2
	public void level2(){
		if (levelLocked [0] == false) {
			SceneManager.LoadScene("level2v1");
			GameManager.level = 2;
		}
	}

	//how to play button
	public void howtoplay(){
		htp.SetActive (true);
		menu.SetActive(false);

	}

	//back
	public void backfromHTP(){
		htp.SetActive (false);
		menu.SetActive(true);

		
	}
}
