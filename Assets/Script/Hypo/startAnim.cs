using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startAnim : MonoBehaviour {
    public GameObject theX;
    public GameObject theLand;
    public GameObject theCha;
    public float standHeight = 2f;
    public Animator animS;
    public GameObject[] bulbs;
    public GameObject theBGM;
    public GameObject theHTP;
    public GameObject htpPage;
    public GameObject theLV1;
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

		
	}
	
	// Update is called once per frame
	void Update () {
        if(theX.transform.position.y>standHeight){
            theX.transform.position = new Vector3(theX.transform.position.x,theX.transform.position.y-1,theX.transform.position.z);
        }else{
            theX.transform.position = new Vector3(0.6f,standHeight,-1.3f);
        }

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
                    //if(i==8){
                    //    if (timeCount < 310)
                    //        timeCount++;
                    //    if(timeCount == 180)
                    //    {
                    //        bulbs[i].GetComponent<currentMiddle>().isOn = true;
                    //        bulbs[i].GetComponent<mouseInteraction>().canInter = true;
                    //        theHTP.SetActive(true);
                    //        theHTP.GetComponent<Animator>().SetBool("showTxt", true);
                    //    }
                    //    if (timeCount == 195)
                    //    {
                    //        //bulbs[0].GetComponent<currentMiddle>().isOn = true;
                    //        //bulbs[0].GetComponent<Animator>().enabled = false;
                    //        bulbs[0].GetComponent<lv1MouseInter>().canInter = true;
                    //        theLV1.SetActive(true);
                    //        theLV1.GetComponent<Animator>().SetBool("showTxt", true);
                    //    }
                    //}
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






        if (!chaTouchDown && theCha.transform.position.y > (24.3f-2.8f))
        {
            theCha.transform.position = new Vector3(theCha.transform.position.x, theCha.transform.position.y - 1, theCha.transform.position.z);
        }
        else
        {
            if (!chaTouchDown)
            {
                theCha.transform.position = new Vector3(0.6f, (24.3f - 2.8f), -2.35f);
                chaTouchDown = true;
            }else{
                if (theCha.transform.position.y < 60)
                {
                    theCha.transform.position = new Vector3(theCha.transform.position.x, theCha.transform.position.y + 1.2f, theCha.transform.position.z);
                }else{
                    theCha.gameObject.SetActive(false);
                    timeCount2++;
                    if(timeCount2 == 45){
                        theDia.SetActive(true);
                    }
                    if (neverGround)
                    {
                        animS.SetBool("isGrounded", true);
                        showBulbs = true;
                        neverGround = false;
                        adSrc.Play();



                    }
                }

            }

        }


        if (theLand.transform.position.y < 0f)
        {
            theLand.transform.position = new Vector3(theLand.transform.position.x, theLand.transform.position.y + 1, theLand.transform.position.z);
        }
        else
        {
            theLand.transform.position = new Vector3(0f, 0f, 0f);

        }


		
	}

    public void backfromHTP()
    {
        htpPage.SetActive(false);
        animS.SetBool("isReady", true);

    }




}

