using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    Guntypes gunType;
    float bulletVel;
    float damage;

    // Use this for initialization
    void Start () {
        gunType = GameObject.FindGameObjectWithTag("Player").GetComponent<Gun>().currentGun;
        bulletVel = gunType.bulletVel;
        damage = gunType.damage;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
