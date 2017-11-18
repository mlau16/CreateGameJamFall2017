using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public Guntypes[] gunType;
    [HideInInspector]
    public Guntypes currentGun;
    public Transform shootRot;
    float shootingTimer;
    int activegun;

    void Start ()
    {
        shootingTimer = 0;
        activegun = 0;
        currentGun = gunType[activegun];

    }
	
	// Update is called once per frame
	void Update ()
    {
        
        ChooseWeapon();
        FireBullet();
    }

    void FireBullet()
    {
        shootingTimer -= Time.deltaTime;

        if (Input.GetMouseButton(0))
        {
            if(shootingTimer <= 0)
            {
                // Shoot please
 
                Bullet bullet = Instantiate(currentGun.bulletPrefab, currentGun.bulletOrigin.position, shootRot.rotation);
                bullet.SetSpeed(currentGun.bulletVel);
                bullet.SetDamage(currentGun.damage);

                shootingTimer = currentGun.shootingRate;
            }
        }
    }

    void ChooseWeapon()
    {
        if (Input.GetKey("1"))
        {
            activegun = 0;
            currentGun = gunType[0];
            currentGun.gunModel.SetActive(true);
            gunType[1].gunModel.SetActive(false);
        }
        if (Input.GetKey("2"))
        {
            activegun = 1;
            currentGun = gunType[1];
            currentGun.gunModel.SetActive(true);
            gunType[0].gunModel.SetActive(false);
        }
    }
}

[System.Serializable]
public class Guntypes
{
    public string name;
    public float shootingRate;
    public GameObject gunModel;
    public Transform bulletOrigin;
    public Bullet bulletPrefab;
    public float bulletVel;
    public float damage;
}