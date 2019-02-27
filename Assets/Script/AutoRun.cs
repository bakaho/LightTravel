using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRun : MonoBehaviour {
    public float indexA = 2.5f;
    public float indexB = 10f;
    float i = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        i += 0.1f;
        transform.position += new Vector3(indexA*Mathf.Sin(i)*i * Time.deltaTime, 0, indexB * Mathf.Cos(i)/(i+1f) * Time.deltaTime);
	}
}
