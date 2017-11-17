using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]



public class Player : MonoBehaviour {

    Rigidbody rb;
    Transform tm;
    Vector3 input = new Vector3();
    float movespeed;


	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        tm = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        //x,y,z

        movespeed = Time.deltaTime * 1000;
        input = GetInput();
        //use this to move player
	}

    private void FixedUpdate()
    {
        rb.AddForce(input * movespeed);
    }

    Vector3 GetInput()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        return new Vector3(x, 0, z);
    }
}
   

