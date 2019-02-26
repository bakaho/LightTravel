//Gao Ya
//54380279
//for further use
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	public GameObject pausedMenu;
	public GameObject pausedBtn;
	public GameObject player;
	public GameObject bgm;

	//get for Sound Effects
	private AudioSource adosrcPlayer;
	private AudioSource adosrcBGM;

	//edit button text
	public Text btnBGMtext;
	public Text btnSEtext;

	static public bool gamePaused = false;
	static public bool bgmOn = true;
	static public bool seOn = true;
	static public int level = 1;


	void Start(){
		adosrcPlayer = player.GetComponent<AudioSource>();
		adosrcBGM = bgm.GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update () {
			
	}

	//pause button
	public void pause(){
		pausedMenu.SetActive (true);
		pausedBtn.SetActive (false);
		Time.timeScale = 0;
		gamePaused = true;
		adosrcBGM.Pause ();
	}

	//resume after pause
	public void resume(){
		pausedMenu.SetActive (false);
		pausedBtn.SetActive (true);
		Time.timeScale = 1;
		gamePaused = false;
		adosrcBGM.UnPause();
	}

	//turn on and off bgm
	public void music(){
		if (bgmOn) {
			btnBGMtext.text = "MUSIC OFF";
			bgmOn = false;
			adosrcBGM.volume = 0;
		} else {
			btnBGMtext.text = "MUSIC ON";
			bgmOn = true;
			adosrcBGM.volume = 0.69f;
		}
	}

	//turn on and off sound effect
	public void soundEffectSwitch(){
		if (seOn) {
			btnSEtext.text = "SOUND EFFECT OFF";
			seOn = false;
			adosrcPlayer.volume = 0;
		} else {
			btnSEtext.text = "SOUND EFFECT ON";
			seOn = true;
			adosrcPlayer.volume = 0.69f;
		}
	}

	//go to next stages
	public void nextStage1to2(){
		level = 2;
		SceneManager.LoadScene("level2v1");
		characterX.winFinished = false;
	}
		
	public void nextStage2to3(){
		level = 3;
        SceneManager.LoadScene("2to3");
        characterX.winFinished = false;
	}

	//back button
	public void toHome(){
        if (level == 1)
        {
            SceneManager.LoadScene("1to2");
        }if(level==2){
            SceneManager.LoadScene("2to3");
        }
		characterX.winFinished = false;
	}

	//the start menu
	public void startmenu(){
		level = 1;
		SceneManager.LoadScene("level1v1");
		characterX.winFinished = false;
	}




}
