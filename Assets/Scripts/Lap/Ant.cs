using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ant : Enemy
{
    [SerializeField]private Vector2 velocity;
    [SerializeField]private Transform[] movePoints;

    public void Start()
    {
        DamageHit = 30;
        rb = GetComponent<Rigidbody2D>();
        Init(40);
        healthBar.SetMaxValue(Health);

        Debug.Log($"Ant's Hp = {Health}");
    }

    private void FixedUpdate()
    {
        Behaviour();
    }

    public override void Behaviour()
    {
        rb.MovePosition(rb.position+velocity*Time.fixedDeltaTime);

        if(rb.position.x <= movePoints[0].position.x && velocity.x < 0)
        {
            Flip();
        }
        else if (rb.position.x >= movePoints[1].position.x && velocity.x > 0)
        {
            Flip();
        }
    }

    public void Flip()
    {
        velocity *= -1;

        Vector3 charScale = transform.localScale;
        charScale.x *= -1;
        transform.localScale = charScale;
    }
}
