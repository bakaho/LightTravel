﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class lv1MouseInter : MonoBehaviour {
    public bool canInter = false;
    public Image wave;
    bool enterFirst = true;
    public AudioClip dripSound;
    private AudioSource adosrc;
    public Animator animW;

    // Use this for initialization
    void Awake()
    {
        adosrc = GetComponent<AudioSource>();
        animW = wave.GetComponent<Animator>();
    }

    void OnMouseEnter()
    {
        if (canInter)
        {
            this.transform.position = new Vector3(this.transform.position.x, -1.1f, this.transform.position.z);
            if (enterFirst)
            {
                adosrc.PlayOneShot(dripSound);
                enterFirst = false;
                animW.SetBool("showWave", true);
            }
        }
    }
    void OnMouseExit()
    {
        if (canInter)
        {
            this.transform.position = new Vector3(this.transform.position.x, 0f, this.transform.position.z);
            enterFirst = true;
        }
    }
    void OnMouseDown()
    {
        if (canInter)
        {
            GameManager.level = 1;
            SceneManager.LoadScene("level1v1");
        }
    }
}
