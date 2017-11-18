using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    float bulletVel;
    float damage;

    public Bullet(float bulletVel, float damage)
    {
        this.bulletVel = bulletVel;
        this.damage = damage;
    }

    void Start ()
    {
        
	}
	
	void Update ()
    {
        float toMove = bulletVel * Time.deltaTime;
        CheckCollisions(toMove);
        transform.Translate(Vector3.forward * toMove);
    }

    private void CheckCollisions(float toMove)
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, toMove))
        {
            OnHitObject(ray, hit);
        }
    }

    private void OnHitObject(Ray ray, RaycastHit hit)
    {
        print(hit.collider.gameObject.name);
        if (hit.collider.gameObject.tag == "enemy")
        {
            IDamageable damageableObject = hit.collider.GetComponent<IDamageable>();
            if (damageableObject != null)
            {
                damageableObject.TakeHit(damage, hit);
            }
            
        } else if (hit.collider.gameObject.tag == "ragdoll") 
        {
            IGiveForce damageableObject = hit.collider.GetComponent<IGiveForce>();
            if (damageableObject != null)
            {
                damageableObject.TakeForce(ray, hit);                
            }
        }
        Destroy(gameObject);
    }

    public void SetSpeed(float speed)
    {
        bulletVel = speed;
    }

    public void SetDamage(float damage)
    {
        this.damage = damage;
    }
}
