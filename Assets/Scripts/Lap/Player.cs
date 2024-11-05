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

    private void Awake()
    {
        Init(100);
        BulletWaitTime = 0.0f;
        BulletTimer = 1.0f;
        healthBar.SetMaxValue(Health);
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
            GameObject objBanana = Instantiate(bullet, bulletSpawnPoint.position, Quaternion.identity);

            Banana banana = objBanana.GetComponent<Banana>();

            banana.Init(20, this);

            BulletWaitTime = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();

        if (enemy != null) 
        {
            OnHitWith(enemy);
        }
    }

    public void OnHitWith(Enemy enemy)
    {
        TakeDamage(enemy.DamageHit);
    }

}
