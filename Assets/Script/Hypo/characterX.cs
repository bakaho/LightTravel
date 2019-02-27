//Gao Ya
//54380279

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class characterX : MonoBehaviour {

	public static characterX instance;
	public static bool winFinished = false;
	public GameObject nextStagePage;
    GameObject[] flipObj1;
    GameObject[] flipObj2;


	//show light of bulb
	public GameObject[] bulbLight;

	//text of restart
	public TextMesh deathNote;
	
	//the respawn point
	public GameObject reborn;

	//the animator
	static Animator anim;
	//NavMeshAgent nav;

	//the destination 
	static public Transform moveHolder;

	bool hintOn = false;
    bool firstHint = true;

    public AudioClip heySound;
    private AudioSource adosrc;
    private int layerMask = ~(1 << 10);

    // Use this for initialization



        



	void Awake() {
		instance = this;
		anim = GetComponent<Animator> ();
		moveHolder = new GameObject("MoveHolder").transform;
		moveHolder.SetParent(this.transform.parent);
		moveHolder.position = this.transform.position;
        adosrc = GetComponent<AudioSource>();
		//moveHolder.position = Vector3 (0);
        flipObj1 = GameObject.FindGameObjectsWithTag("moveBar1");
        flipObj2 = GameObject.FindGameObjectsWithTag("moveBar2");
	}
	void Update () {
		if (!GameManager.gamePaused && !winFinished) {
			if(Input.GetMouseButtonDown(0))
			{
				if (deathNote.gameObject.activeInHierarchy) {
					deathNote.gameObject.SetActive (false);

					hintOn = false;
				}

				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

				RaycastHit hit = new RaycastHit();
				if (Physics.Raycast(ray, out hit,500f,layerMask))
				{
					if (hit.collider.name == "Land")
					{
						print (transform.position.y +" to "+hit.point.y);
					
						if(Mathf.Abs(transform.position.y-hit.point.y)<1f){
							moveHolder.position = hit.point;
							//turn to the mouse direction
							transform.LookAt (new Vector3(moveHolder.position.x,transform.position.y,moveHolder.position.z));
							//print (moveHolder.position);
							//nav.SetDestination (pos);
						}
					}
				}
			}

			//move
			Vector3 offset = moveHolder.position - transform.position;
			transform.position += offset.normalized * 25 * Time.deltaTime;
			if(Vector3.Distance(moveHolder.position, transform.position)<1.5f) {
				transform.position = moveHolder.position;
				anim.SetBool ("IsRunning", false);
			}
			else {
				anim.SetBool ("IsRunning", true);
			}

			//if die
			if (anim.GetBool ("IsDead")) {
				//press any key to restart

				deathNote.text = "Short circuit is killing me :(\nPress Space to Restart";
				deathNote.gameObject.transform.position = this.transform.position+new Vector3(0,10,0);
				deathNote.gameObject.SetActive(true);

				if (Input.GetKeyDown("space")) {				
					if (GameManager.level == 2) {
						SceneManager.LoadScene ("level2v1");
					} else {
						//transform.position = reborn.transform.position;
						//moveHolder.position = this.transform.position;
						//this.ResetState();
                        SceneManager.LoadScene("level1v1");
					}
				}
			}
		}

		//show hints
		if (hintOn) {
			deathNote.text = "I remember there were some hidden path...";
            if (firstHint)
            {
                adosrc.PlayOneShot(heySound);
                firstHint = false;
            }
			deathNote.gameObject.transform.position = this.transform.position+new Vector3(0,10,0);
		}
	}

	public void ResetState() {
		anim.SetBool ("IsDead", false);
		anim.SetBool ("IsWin", false);
		deathNote.gameObject.SetActive(false);
	}

	public void UpdateState(bool win) {
		this.ResetState();
		moveHolder.position = transform.position;
		if (win) {
			anim.SetBool ("IsWin", true);
			for (int i = 0; i < bulbLight.Length; i++) {
				bulbLight [i].SetActive (true);
			}
		}
		else {
			anim.SetBool ("IsDead", true);
		}
	}

	void WinAfter(){
		winFinished = true;
		nextStagePage.SetActive (true);
		if (GameManager.level == 1) {
			StartManager.levelLocked [0] = false;
		}

	}

	//send hints
	void OnTriggerEnter(Collider box) {
		if (box.tag == "hint") {
			hintOn = true;
			deathNote.gameObject.SetActive(true);
			box.gameObject.SetActive (false);
		}
        if (box.tag == "can'tmove")
        {
            for (int i = 0; i < flipObj1.Length; i++){
                //obj1On = !obj1On;
                flipObj1[i].gameObject.SetActive(false);
            }
        }
        if (box.tag == "can'tmove2")
        {
            for (int i = 0; i < flipObj2.Length; i++)
            {
                flipObj2[i].gameObject.SetActive(false);
            }
        }
	}

	//private void OnTriggerStay(Collider box)
	//{
 //       if (box.tag == "can'tmove")
 //       {
 //           hintOn = true;
 //           deathNote.gameObject.SetActive(true);
 //           box.gameObject.SetActive(false);
 //       }
	//}

    private void OnTriggerExit(Collider box)
    {
        if (box.tag == "can'tmove")
        {
            for (int i = 0; i < flipObj1.Length; i++)
            {
                flipObj1[i].gameObject.SetActive(true);
            }
        }
        if (box.tag == "can'tmove2")
        {
            for (int i = 0; i < flipObj2.Length; i++)
            {
                flipObj2[i].gameObject.SetActive(true);
            }
        }

    }
}
