using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]



public class Player : LivingEntity
{
    Rigidbody rb;
    Transform tm;
    Vector3 input = new Vector3();
    float movespeed;
    public CollisionDetectionMode collisionDetectionMode = CollisionDetectionMode.Continuous;
    bool damageable = true;


    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody>();
        tm = GetComponent<Transform>();
        
	}

    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag == "enemy" && damageable == true)
        {
            health = health - 1;
            print("Health: " + health);
        }
    }

    IEnumerator decreaseHealth()
    {
        print(Time.time);
        yield return new WaitForSeconds(5);
        print(Time.time);
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
   

