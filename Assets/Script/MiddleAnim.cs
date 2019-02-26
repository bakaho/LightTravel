using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleAnim : MonoBehaviour {
    public GameObject theX;
    public GameObject theLand;
    public float standHeight = 2f;
    public Animator animS;
    public GameObject[] bulbs;
    public GameObject theBGM;
    public GameObject theHTP;
    public GameObject htpPage;
    public GameObject theLV1;
    public GameObject theLV2;
    public GameObject theDia;
    public AudioSource adSrc;


    int timeCount = 0;
    int timeCount2 = 0;
    bool htpOn = false;
    bool lv1On = false;

    bool neverGround = true;
    bool chaTouchDown = false;
    bool showBulbs = false;
    public bool[] bulbUp = { false, false, false, false, false, false, false };
    public int[] bulbDir = { 1, 1, 1, 1, 1, 1, 1 };

	// Use this for initialization
	void Start () {
        animS = theX.GetComponent<Animator>();
        adSrc = theBGM.GetComponent<AudioSource>();
        animS.SetBool("isReady", true);
        showBulbs = true;
        neverGround = false;
        adSrc.Play();
		
	}
	
	// Update is called once per frame
	void Update () {
        //if(theX.transform.position.y>standHeight){
        //    theX.transform.position = new Vector3(theX.transform.position.x,theX.transform.position.y-1,theX.transform.position.z);
        //}else{
        //    theX.transform.position = new Vector3(0.6f,standHeight,-1.3f);
        //}


        if (showBulbs)
        {
            for (int i = 0; i < bulbs.Length; i++)
            {
                print(bulbUp.Length);
                if (!bulbUp[i] && bulbs[i].transform.position.y < 0.1f)
                {
                    bulbs[i].transform.position = new Vector3(bulbs[i].transform.position.x, bulbs[i].transform.position.y + 0.5f, bulbs[i].transform.position.z);
                }
                else
                {
                    bulbUp[i] = true;
                    if(i==8){
                        if (timeCount < 310)
                            timeCount++;
                        if(timeCount == 30)
                        {
                            bulbs[i].GetComponent<mouseInteraction>().canInter = true;
                            theHTP.SetActive(true);
                            theHTP.GetComponent<Animator>().SetBool("showTxt", true);
                        }
                        if (timeCount == 45)
                        {
                            bulbs[0].GetComponent<lv1MouseInter>().canInter = true;
                            theLV1.SetActive(true);
                            theLV1.GetComponent<Animator>().SetBool("showTxt", true);
                        }
                        if (timeCount == 60)
                        {
                            bulbs[3].GetComponent<lv2MouseInter>().canInter = true;
                            theLV2.SetActive(true);
                            theLV2.GetComponent<Animator>().SetBool("showTxt", true);
                        }
                    }
                    if (bulbs[i].transform.position.y > -1.05f)
                    {
                        if (bulbs[i].transform.position.y >= 1.1f)
                        {
                            bulbDir[i] *= -1;
                            bulbs[i].transform.position = new Vector3(bulbs[i].transform.position.x, 1.1f, bulbs[i].transform.position.z);
                        }
                        else if (bulbs[i].transform.position.y <= -1f)
                        {
                            bulbDir[i] *= -1;
                            bulbs[i].transform.position = new Vector3(bulbs[i].transform.position.x, -1f, bulbs[i].transform.position.z);
                        }
                        bulbs[i].transform.position = new Vector3(bulbs[i].transform.position.x, bulbs[i].transform.position.y + 0.01f * bulbDir[i], bulbs[i].transform.position.z);
                    }

                    

                }
            }
        }





		
	}

    public void backfromHTP()
    {
        htpPage.SetActive(false);
        //animS.SetBool("isReady", true);

    }





}

