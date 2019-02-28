using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageHints : MonoBehaviour {

    int hintTotal;
    // Use this for initialization
	void Start () {
        hintTotal = transform.childCount;
        for (int i = 0; i < hintTotal; ++i){
            transform.GetChild(i).gameObject.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if(myLight.theTriggerOne == -1){
            for (int i = 0; i < hintTotal; ++i)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }else{
            transform.GetChild(myLight.theTriggerOne).gameObject.SetActive(true);
        }
	}
}
