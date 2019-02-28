using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzleManager : MonoBehaviour {

    int puzTotal;
    public int thisPiece = 0;
    public bool updateNow = false;
    // Use this for initialization
    void Start()
    {
        puzTotal = transform.childCount;
        for (int i = 0; i < puzTotal; ++i)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        transform.GetChild(0).gameObject.SetActive(true); 
    }

    // Update is called once per frame
    void Update()
    {
        if(updateNow){
            updatePiece();
            updateNow = false;
        }
    }

    public void updatePiece(){
        for (int i = 0; i < puzTotal; ++i)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        transform.GetChild(thisPiece).gameObject.SetActive(true);       
    }


}
