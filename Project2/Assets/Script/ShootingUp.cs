using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingUp : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 5f;

    private float nextShootTimer;

    

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Time.time > nextShootTimer)
        {
            bulletPrefab.transform.localRotation = Quaternion.Euler(0, 0, 90);
            Shoot();
            float fireRate = .2f;
            nextShootTimer = Time.time + fireRate;
        }


    }
    /*private void FixedUpdate()
    {
        
    }*/

    void Shoot()
    {       
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce((firePoint.up) * bulletForce, ForceMode2D.Impulse);
    }
}
