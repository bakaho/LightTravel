using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveControl : MonoBehaviour
{

    public float xDel, yDel;
    public Camera myCam;
    bool moveAllow = false;
    Touch initTouch;
    Vector3 initMouse;

    // Update is called once per frame
    private void Start()
    {
        myCam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
    }
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            initMouse = Input.mousePosition;
            moveAllow = true;

            //Ray ray = uiCam.ScreenPointToRay(Input.mousePosition);
            //RaycastHit hit = new RaycastHit();
            //if (Physics.Raycast(ray, out hit))
            //{
            //    if (hit.transform.gameObject == this.gameObject)
            //    {
            //        print("hit!");
            //        rotateAllow = true;
            //    }
            //}
        }
        else if (Input.GetMouseButton(0))
        {
            float xMoved = Input.mousePosition.x - initMouse.x;
            float yMoved = Input.mousePosition.y - initMouse.y;
            //float distance = Mathf.Sqrt((xMoved * xMoved) + (xMoved * xMoved));
            if (moveAllow)
            {

                if (xMoved > 50)
                {
                    xDel = 2;
                }
                else if (xMoved < -50)
                {
                    xDel = -2;
                }
                else
                {
                    xDel = xMoved / 50f;
                }

                if (yMoved > 50)
                {
                    yDel = 2;
                }
                else if (yMoved < -50)
                {
                    yDel = -2;
                }
                else
                {
                    yDel = yMoved / 50f;
                }

            }

        }
        //if let go, start over again
        else if (Input.GetMouseButtonUp(0))
        {
            moveAllow = false;
        }


    }

    public float Horizontal()
    {
        if (moveAllow)
        {
            print("0");
            return xDel;

        }
        else
        {
            //print("1");
            return Input.GetAxis("Horizontal");

        }
    }

    public float Vertical()
    {
        if (moveAllow)
        {
            //print("2");
            return yDel;

        }
        else
        {
            //print("3");
            return Input.GetAxis("Vertical");

        }
    }
}
