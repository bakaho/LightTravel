﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class myLight : NetworkBehaviour {

    //move
    public moveControl joystick;
    public float speed = 15;
    public static bool inControl = true;
    //cam
    public Transform CameraTransform;
    private Vector3 cameraOffset;
    //hit
    public static int theTriggerOne = -1;
    //form
    public static int lightShape = 0;
    public static bool shapeChange = false;

    //testing
    public static bool showT3 = false;



    [Range(0.01f, 1.0f)]
    public float smoothFactor = 0.01f;

	// Use this for initialization
	void Start () {
        joystick = GameObject.FindWithTag("joystick").GetComponent<moveControl>();

        //initialization of camera
        CameraTransform = GameObject.FindWithTag("MainCamera").transform;
        cameraOffset = CameraTransform.transform.position - new Vector3(0f, 0f, 0f);

	}

	public override void OnStartLocalPlayer()
	{
        //base.OnStartLocalPlayer();
        transform.GetChild(1).gameObject.SetActive(false);
        transform.GetChild(0).gameObject.SetActive(true);
	}

	// Update is called once per frame
	void Update () {
        if(!isLocalPlayer){
            return;
        }

        if (shapeChange){
            
            for (int i = 0; i < transform.childCount; ++i)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
            transform.GetChild(lightShape).gameObject.SetActive(true); 
            shapeChange = false;
        } 

        float h = joystick.Horizontal();
        float v = joystick.Vertical();
        bool move = (Mathf.Abs(v - 0) > 0.001f) || (Mathf.Abs(h - 0) > 0.001f);
        //print("camera: " + CameraTilt.canMove);
        //print("this: " + inControl);
        //print("this: " + h);

        if(move && CameraTilt.canMove && inControl){
            //Vector3 newPos = transform.position + new Vector3(speed * h * Time.deltaTime, 0, speed * v * Time.deltaTime);
            transform.position += new Vector3(speed * h * Time.deltaTime, 0, speed * v * Time.deltaTime);

        }
        Vector3 newCamPos = transform.position + cameraOffset;
        CameraTransform.position = Vector3.Slerp(CameraTransform.position, newCamPos, smoothFactor);


		
	}

    void OnTriggerEnter(Collider other)
    {
        if (!isLocalPlayer)
        {
            return;
        }
        if (other.gameObject.CompareTag("puz1"))
        {
            theTriggerOne = 0;
        }
        if (other.gameObject.CompareTag("puz2"))
        {
            theTriggerOne = -1;
            showT3 = true;

        }
    }

    //void OnTriggerStay(Collider other)
    //{
    //    if (other.gameObject.CompareTag("puz1"))
    //    {
    //        theTriggerOne = 0;
    //    }
    //}

    //void OnTriggerExit(Collider other)
    //{
    //    theTriggerOne = -1;
    //}
}
