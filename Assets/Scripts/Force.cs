using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Force : MonoBehaviour {

    Rigidbody body;

    // Use this for initialization
    void Start () {
        body = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        float x = Input.GetAxis("Fire1");

        if(x > 0)
        {
            body.AddForce(new Vector3(1, 50, 0));
        }
		
	}
}
