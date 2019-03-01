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
    public GameObject playerLight;
    public GameObject flwCam;

    //testing
    public GameObject txt3;
    public Button showShape;

    //levels
    public bool[] passedItems;
    public GameObject[] puzMags;
    //level1
    public GameObject l1Hat;


    public int counter = 0;
    bool firstTouch = true;

	//get for Sound Effects
	private AudioSource adosrcPlayer;
	private AudioSource adosrcBGM;
    public AudioClip finishSound;
    public AudioSource adosrcFinish;

	//edit button text
	public Text btnBGMtext;
	public Text btnSEtext;

	static public bool gamePaused = false;
	static public bool bgmOn = true;
	static public bool seOn = true;
	static public int level = 1;


    void Awake(){
        adosrcFinish = GetComponent<AudioSource>();
        adosrcPlayer = player.GetComponent<AudioSource>();
        adosrcBGM = bgm.GetComponent<AudioSource>();
    }
    void Start(){
		//playerLight = 

	}

	// Update is called once per frame
	void Update () {

        if(firstTouch && Input.touchCount >= 2){
            //play sound
            counter = 60;
            firstTouch = false;
            checkCorrect();
            checkChange();
        }

        if(counter>0){
            CameraTilt.canMove = false;
            counter-=1;
        }else if(counter == 0){
            CameraTilt.canMove = true;
            firstTouch = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            myLight.inControl = true;
        }

        if(myLight.showT3){
            txt3.SetActive(true);
        }

			
	}

    public void checkCorrect(){
        if(myLight.theTriggerOne == 0 && !passedItems[0]){
            //if correct
            if (Mathf.Abs((float)(flwCam.transform.position.x - 83.3)) < 3
                && Mathf.Abs((float)(flwCam.transform.position.z + 75)) < 3)
               //&& Mathf.Abs((float)(flwCam.transform.rotation.eulerAngles.x - 27)) < 3
               //&& Mathf.Abs((float)(flwCam.transform.rotation.eulerAngles.y + 0.5)) < 3)
            {
                adosrcFinish.PlayOneShot(finishSound);
                print("playsound");
                l1Hat.SetActive(true);
                puzMags[0].GetComponent<puzzleManager>().thisPiece += 1;
                puzMags[0].GetComponent<puzzleManager>().updateNow = true;
                passedItems[0] = true;
                myLight.theTriggerOne = -1;
                myLight.inControl = true;
            }
        }
        
    }

    public void checkChange(){
        if (Mathf.Abs((float)(flwCam.transform.position.x - 83.3)) < 3
                && Mathf.Abs((float)(flwCam.transform.position.z + 75)) < 3)
        //&& Mathf.Abs((float)(flwCam.transform.rotation.eulerAngles.x - 27)) < 3
        //&& Mathf.Abs((float)(flwCam.transform.rotation.eulerAngles.y + 0.5)) < 3)
        {
            showShape.gameObject.SetActive(true);
        }
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
