using System.Collections;
using System.Collections.Generic;
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

    private void Awake()
    {
        Init(100);
        BulletWaitTime = 0.0f;
        BulletTimer = 1.0f;
    }

    private void FixedUpdate()
    {
        BulletWaitTime += Time.fixedDeltaTime;
        if (Input.GetButtonDown("Fire1") && BulletWaitTime > BulletTimer)
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        if (BulletWaitTime >= BulletTimer)
        {
            GameObject obj = Instantiate(bullet, bulletSpawnPoint.position, Quaternion.identity);
            BulletWaitTime = 0;
        }
    }
}
