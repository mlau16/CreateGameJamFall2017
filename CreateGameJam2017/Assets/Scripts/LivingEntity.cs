using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Extends damage interface
[System.Serializable]
public class LivingEntity : MonoBehaviour, IDamageable
{
    public float startingHealth;
    public float health;
    protected bool dead;
    public Ragdoll ragdoll;
    public Transform Blood_FX;

    protected virtual void Start()
    {
        health = startingHealth;
    }

    public void TakeHit(float damage, RaycastHit hit)
    {
        health -= damage;
        if (health <= 0 && !dead)
        {
            Die();
        }
    }

    protected void Die()
    {
        Instantiate(Blood_FX, transform.position, Quaternion.identity);
        for (int i = 0; i < Random.Range(1,4); i++)
        {
            Instantiate(ragdoll, transform.position, transform.rotation);
        }

        dead = true;
        GameObject.Destroy(gameObject);
        
    }
}