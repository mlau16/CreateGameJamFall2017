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
        dead = true;
        GameObject.Destroy(gameObject);
        
    }
}