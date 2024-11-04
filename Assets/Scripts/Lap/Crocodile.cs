using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Crocodile : Enemy, IShootable
{
    private float attackRange;
    public float AttackRange
    { get { return attackRange; } set { attackRange = value; } }

    public Player player;

    [field: SerializeField]
    GameObject bullet;
    public GameObject Bullet
    { get { return bullet; } set {  bullet = value; } }

    [field: SerializeField]
    Transform bulletSpawnPoint;
    public Transform BulletSpawnPoint
    { get { return bulletSpawnPoint; } set { bulletSpawnPoint = value; } }

    public float BulletWaitTime
    { get; set; }

    public float BulletTimer
    { get; set; }

    private void Start()
    {
        Init(30);
        BulletWaitTime = 0.0f;
        BulletTimer = 6.0f;
        AttackRange = 6f;
        player = GameObject.FindObjectOfType<Player>();
    }

    private void FixedUpdate()
    {
        BulletWaitTime += Time.fixedDeltaTime;

        Behaviour();
    }

    public override void Behaviour()
    {
        Vector2 direction = player.transform.position-transform.position;
        float distance = direction.magnitude;

        if (distance < attackRange)
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        if (BulletWaitTime >= BulletTimer)
        {
            GameObject obj = Instantiate(bullet, bulletSpawnPoint.position, Quaternion.identity);

            Destroy(obj);
            
            BulletWaitTime = 0;
        }
    }
}
