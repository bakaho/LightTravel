using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myLight : MonoBehaviour {

    //move
    public moveControl joystick;
    public float speed = 15;
    //cam
    public Transform CameraTransform;
    private Vector3 cameraOffset;

    //
    [Range(0.01f, 1.0f)]
    public float smoothFactor = 0.5f;

	// Use this for initialization
	void Start () {
        joystick = GameObject.FindWithTag("joystick").GetComponent<moveControl>();

        //initialization of camera
        CameraTransform = GameObject.FindWithTag("MainCamera").transform;
        cameraOffset = CameraTransform.transform.position - new Vector3(0f, 0f, 0f);
	}
	
	// Update is called once per frame
	void Update () {

        float h = joystick.Horizontal();
        float v = joystick.Vertical();
        bool move = (Mathf.Abs(v - 0) > 0.01f) || (Mathf.Abs(h - 0) > 0.01f);
        if(move){
            //Vector3 newPos = transform.position + new Vector3(speed * h * Time.deltaTime, 0, speed * v * Time.deltaTime);
            transform.position += new Vector3(speed * h * Time.deltaTime, 0, speed * v * Time.deltaTime);

        }
        Vector3 newCamPos = transform.position + cameraOffset;
        CameraTransform.position = Vector3.Slerp(CameraTransform.position, newCamPos, smoothFactor);

        //transform.position += new Vector3(speed * h * Time.deltaTime, 0, speed * v * Time.deltaTime);

        //float fXMove = Input.GetAxis("Horizontal") * Time.deltaTime * 150f;
        //float fZMove = Input.GetAxis("Vertical") * Time.deltaTime * 150f;

        //transform.Translate(fXMove, 0, fZMove);
		
	}
}
