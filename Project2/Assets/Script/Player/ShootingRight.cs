using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShootingRight : MonoBehaviour
{
    [SerializeField]
    Transform firePoint;

    [SerializeField]
    GameObject bulletPrefab;

    [SerializeField]
    float bulletForce = 5f;

    private float nextShootTimer;

    void Start() { }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.time > nextShootTimer)
        {
            Shoot();
            float fireRate = .2f;
            nextShootTimer = Time.time + fireRate;
        }
    }

    /// <summary>
    /// Instantiates the projectile in the determined direction
    /// </summary>
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce((firePoint.right) * bulletForce, ForceMode2D.Impulse);
    }
}
