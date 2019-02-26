using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class storyManager : MonoBehaviour {
    public string[] talking;
    public Text talkTxt;
    public int totNum;
    int textCount = 0;
    public AudioClip sparkSound;
    private AudioSource adosrc;

	// Use this for initialization
	void Start () {
        talkTxt.text = talking[0];
	}
    void Awake()
    {
        adosrc = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        
		
	}

    public void nextPage(){
        textCount++;
        if (textCount <= totNum)
        {
            talkTxt.text = talking[textCount];
        }else{
            SceneManager.LoadScene("beforeE");
        }
    }
    public void moveOn()
    {
        SceneManager.LoadScene("BeforeOpen");
    }



    // Use this for initialization


    public void sparking()
    {
        //set the food step sound
        if (Random.Range(-5f, 10.0f) < 0)
        {
            adosrc.PlayOneShot(sparkSound);
        }
    }
}
