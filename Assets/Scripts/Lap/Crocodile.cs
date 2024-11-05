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
        DamageHit = 50;
        Init(80);
        BulletWaitTime = 0.0f;
        BulletTimer = 4.0f;
        AttackRange = 6f;
        player = GameObject.FindObjectOfType<Player>();
        healthBar.SetMaxValue(Health);
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
            anime.SetTrigger("Shoot");

            GameObject rockObj = Instantiate(bullet, bulletSpawnPoint.position, Quaternion.identity);

            Rock rockScript = rockObj.GetComponent<Rock>();

            rockScript.Init(20 , this);

            BulletWaitTime = 0;
        }
    }
}
