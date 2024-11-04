using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : Character, IShootable
{
    [field: SerializeField]
    GameObject bullet;

    public GameObject Bullet
    { get { return bullet; } set { bullet = value; } }

    [field: SerializeField]
    Transform bulletSpawnPoint;
    public Transform BulletSpawnPoint
    { get { return bulletSpawnPoint; } set { bulletSpawnPoint = value; } }

    public float BulletWaitTime
    { get; set; }

    public float BulletTimer
    { get; set; }

    //public HealthBar healthBar;

    private void Awake()
    {
        Init(100);
        BulletWaitTime = 0.0f;
        BulletTimer = 1.0f;
        //healthBar.SetMaxValue(Health);
    }

    private void FixedUpdate()
    {
        BulletWaitTime += Time.fixedDeltaTime;
        

        if (Input.GetButtonDown("Fire1") && BulletWaitTime > BulletTimer)
        {
            Shoot();
        }

        /*
        if (Input.GetKey(KeyCode.F))
        {
            TakeDamage(10);
            healthBar.UpdateHealthBar(Health);
        }
        */
    }

    public void Shoot()
    {
        if (BulletWaitTime >= BulletTimer)
        {
            GameObject obj = Instantiate(bullet, bulletSpawnPoint.position, Quaternion.identity);

            Destroy(obj,3);

            BulletWaitTime = 0;
        }
    }
}
