using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[System.Serializable]
public class Ragdoll : MonoBehaviour {
    Transform ragdolltransform;
    Rigidbody rb;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        rb.mass = Random.Range(10f, 40);
        print("Object is built");

        transform.localScale = new Vector3(Random.Range(0.2f, 2), Random.Range(0.2f, 1), Random.Range(0.2f, 2));
        rb.AddForce(new Vector3(0, Random.Range(0.2f, 15), 0), ForceMode.Impulse);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
