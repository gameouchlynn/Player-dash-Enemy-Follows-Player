    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
   
    public GameObject Bullet;

    public Transform ShootPoint, firePoint;

    public float bulletSpeed = 20f;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

   
    
    void Shoot()
    {
        GameObject bullet = Instantiate(Bullet, ShootPoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(ShootPoint.up * bulletSpeed, ForceMode2D.Impulse);
        transform.position += transform.forward * bulletSpeed * Time.deltaTime;
          Destroy(bullet, 5.0f);
    }
}

