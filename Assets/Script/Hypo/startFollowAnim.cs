using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class startFollowAnim : MonoBehaviour {
    Animator animMe;
    public GameObject htp;
    public GameObject lv1;
    public GameObject htpBulb;
    public GameObject lv1Bulb;
    public Image dia2;
    public AudioClip sighSound;
    private AudioSource adosrc;



    void Awake()
    {
        animMe = GetComponent<Animator>();
        adosrc = GetComponent<AudioSource>();
    }

    void CheckAroundEnd()
    {
        animMe.SetBool("isGrounded", false);
        animMe.SetBool("beSad", true);
    }

    public void showMenu()
    {

        htpBulb.GetComponent<currentMiddle>().isOn = true;
        htpBulb.GetComponent<mouseInteraction>().canInter = true;
        htp.SetActive(true);
        htp.GetComponent<Animator>().SetBool("showTxt", true);


    }
    public void showMenu2()
    {
        lv1Bulb.GetComponent<lv1MouseInter>().canInter = true;
        lv1.SetActive(true);
        lv1.GetComponent<Animator>().SetBool("showTxt", true);

    }

    void Sigh()
    {
        adosrc.PlayOneShot(sighSound);
    }

    void dialog2(){
        dia2.gameObject.SetActive(true);
    }


}
